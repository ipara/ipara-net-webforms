using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using IparaPayment.Payment.Ipara.Entity;

namespace IparaPayment.Payment.Ipara
{
    /// <summary>
    /// Ornek IPara odemesinin hazirlanmasi icin tasarlanmistir. <value> ipara base url + "/rest/payment/auth"</value> uzerinden hazirlanmis olan odeme istegini gonderir.
    /// <para>
    /// Ornek kod icindeki akista gerekli parametrelerin ortak yönetimi icin <see cref="IparaPayment.Payment.Ipara.Settings"/> class'ini inceleyiniz.
    /// </para>
    /// 
    /// </summary>
    public class IparaRequest
    {
        /// <summary>
        /// <para><param name="authUrl">Ipara API URL degerini hazirlar.</param></para>
        /// <para><paramref name="BaseIparaAPIUrl"/> parametresinin ayrintilari icin bakiniz: <seealso cref="Settings"/></para>
        /// </summary>
        private string authUrl = Settings.BaseIparaAPIUrl + "/rest/payment/auth";
        /// <summary>
        /// <para><param name="authUrl">Ipara Three 3 sogulamasi icin URL degerini hazirlar.</param></para>
        /// <para><paramref name="BaseIparaThreeDUrl"/> parametresinin ayrintilari icin bakiniz: <seealso cref="Settings"/></para>
        /// </summary>
        private string threeDUrl = Settings.BaseIparaThreeDUrl + "/3dgate";
        /// <summary>
        /// <para><param name="authUrl">Kullanilan IPara API versiyonunu belirtir.</param></para>
        /// <para><paramref name="Version"/> parametresinin ayrintilari icin bakiniz: <seealso cref="Settings"/></para>
        /// </summary>
        private string version = Settings.Version;

        private string privateKey { get; set; }
        private string publicKey { get; set; }

        /// <summary>
        /// <para>
        /// Ornek IPara odemesinin hazirlanmasi icin tasarlanmistir. <value> ipara base url + "/rest/payment/auth"</value> uzerinden hazirlanmis olan odeme istegini gonderir.
        /// Magazaniza ait size iletilmis olan Acik-Gizli Anahtar bilgisine ihtiyac duyar.
        /// </para>
        /// <para>
        /// Ornek kod icindeki akista gerekli parametrelerin ortak yönetimi icin <see cref="IparaPayment.Payment.Ipara.Settings"/> class'ini inceleyiniz.
        /// </para>
        /// </summary>
        public IparaRequest(string publicKey, string privateKey)
        {
            this.privateKey = privateKey;
            this.publicKey = publicKey;
        }

        // API ile Odeme Metodu
        public PaymetResponse Pay(IparaAuth auth)
        {
            auth.ThreeD = "false";
            string xmlData = IparaRequestUtil.SerializeObject(auth);

            if (!string.IsNullOrEmpty(xmlData))
            {
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string hashText = this.privateKey + auth.OrderId + auth.Amount + auth.Mode + auth.CardOwnerName +
                   auth.CardNumber + auth.CardExpireMonth + auth.CardExpireYear + auth.Cvc + auth.Purchaser.Name + auth.Purchaser.SurName + auth.Purchaser.Email + dateTime;

                string token = this.publicKey + ":" + IparaRequestUtil.GetSHA1(hashText);

                string response = IparaRequestUtil.ApiRequest(token, this.version, dateTime, xmlData, this.authUrl);

                PaymetResponse paymentResponse = IparaRequestUtil.DeserializeObject<PaymetResponse>(response);

                ValidateResponse(paymentResponse);

                return paymentResponse;
            }
            else
                throw new Exception("Ödeme isteği gönderilirken beklenmedik bir hata oluştu!");
        }

        /// <summary>
        /// 3D Secure ile odeme metodudur. 3D sorgulamasi sonrasinda basarili sonuc alinmasini takiben cagrilmalidir. 3D sorgulamasi sonrasi odemenin otorizasyon asamasinin tamamlanmasini saglar.
        /// </summary>
        /// <param name="auth"> : odeme otorizasyonunun saglanmasi icin gerekli bilgileri iceren objedir.</param>
        public PaymetResponse PayThreeDResult(IparaAuth auth)
        {
            auth.CardExpireMonth = null;
            auth.CardExpireYear = null;
            auth.CardNumber = null;
            auth.CardOwnerName = null;
            auth.Purchaser.Name = null;
            auth.Purchaser.SurName = null;
            auth.Purchaser.Email = null;
            auth.Purchaser.ClientIp = null;
            auth.ThreeD = "true";

            string xmlData = IparaRequestUtil.SerializeObject(auth);

            if (!string.IsNullOrEmpty(xmlData))
            {
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string hashText = this.privateKey + auth.OrderId + auth.Amount + auth.Mode + auth.ThreeDSecureCode + dateTime;

                string token = this.publicKey + ":" + IparaRequestUtil.GetSHA1(hashText);

                string response = IparaRequestUtil.ApiRequest(token, this.version, dateTime, xmlData, this.authUrl);

                PaymetResponse paymentResponse = IparaRequestUtil.DeserializeObject<PaymetResponse>(response);

                ValidateResponse(paymentResponse);

                return paymentResponse;
            }
            else
                throw new Exception("Ödeme isteği gönderilirken beklenmedik bir hata oluştu!");
        }

        /// <summary>
        /// 3D Secure ile Odeme Oncesi 3D sorgulaması gerceklestirilmesi icin gerekli metottur. Bu asama basari ile sonuclanir ise islemin metoda girilmis olan <paramref name="successUrl"/><param/> uzerinden
        /// 3D odemenin tamamlanmasi icin hazirlanmis bir kurguya yonlenmesi beklenir.
        /// <remarks><para>Ayrica Bakiniz : <seealso cref="IparaPaymentDemo.ThreeDResult"/></para></remarks>
        /// </summary>
        /// <param name="auth"> : odeme otorizasyonunun saglanmasi icin gerekli bilgileri iceren objedir.</param>
        /// <param name="successUrl"> : basarili 3D odeme sorgusu sonunda, sonucun post edilecegi yeniden yonlenme URL adresidir.</param>
        /// <param name="failureUrl"> : basarisiz 3D odeme sorgusu sonucunun post edilecegi yeniden yonlenme URL adresidir.</param>
        public void PayThreeD(IparaAuth auth, String successUrl, String failureUrl)
        {
            auth.ThreeD = "true";

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string hashText = this.privateKey + auth.OrderId + auth.Amount + auth.Mode + auth.CardOwnerName +
               auth.CardNumber + auth.CardExpireMonth + auth.CardExpireYear + auth.Cvc + auth.Purchaser.Name + auth.Purchaser.SurName + auth.Purchaser.Email + dateTime;

            string token = this.publicKey + ":" + IparaRequestUtil.GetSHA1(hashText);

            StringBuilder builder = new StringBuilder();

            builder.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            builder.Append("<html>");
            builder.Append("<body>");
            builder.Append("<form action=\"" + this.threeDUrl + "\" method=\"post\" id=\"three_d_form\"/>");
            builder.Append("<input type=\"hidden\" name=\"orderId\" value=\"" + auth.OrderId + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"amount\" value=\"" + auth.Amount + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"cardOwnerName\" value=\"" + auth.CardOwnerName + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"cardNumber\" value=\"" + auth.CardNumber + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"cardExpireMonth\" value=\"" + auth.CardExpireMonth + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"cardExpireYear\" value=\"" + auth.CardExpireYear + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"installment\" value=\"" + auth.Installment + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"cardCvc\" value=\"" + auth.Cvc + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"mode\" value=\"" + auth.Mode + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"purchaserName\" value=\"" + auth.Purchaser.Name + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"purchaserSurname\" value=\"" + auth.Purchaser.SurName + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"purchaserEmail\" value=\"" + auth.Purchaser.Email + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"successUrl\" value=\"" + successUrl + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"failureUrl\" value=\"" + failureUrl + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"echo\" value=\"" + auth.Echo + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"version\" value=\"" + this.version + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"transactionDate\" value=\"" + dateTime + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"token\" value=\"" + token + "\"/>");
            builder.Append("<input type=\"submit\" value=\"Öde\" style=\"display:none;\"/>");
            builder.Append("<noscript>");
            builder.Append("<br/>");
            builder.Append("<br/>");
            builder.Append("<center>");
            builder.Append("<h1>3D Secure Yönlendirme İşlemi</h1>");
            builder.Append("<h2>Javascript internet tarayıcınızda kapatılmış veya desteklenmiyor.<br/></h2>");
            builder.Append("<h3>Lütfen banka 3D Secure sayfasına yönlenmek için tıklayınız.</h3>");
            builder.Append("<input type=\"submit\" value=\"3D Secure Sayfasına Yönlen\">");
            builder.Append("</center>");
            builder.Append("</noscript>");
            builder.Append("</form>");
            builder.Append("</body>");
            builder.Append("<script>document.getElementById(\"three_d_form\").submit();</script>");
            builder.Append("</html>");

            HttpContext.Current.Response.Clear();

            HttpContext.Current.Response.Write(builder.ToString());
            HttpContext.Current.Response.End();
        }

        // 3D Secure Sonucunun Islenmesi ve Hash Gecerlilik Kontrolu
        public PaymetResponse GetThreeDResponse(System.Collections.Specialized.NameValueCollection keys)
        {
            PaymetResponse paymentResponse = new PaymetResponse();

            paymentResponse.Result = keys["result"];
            paymentResponse.OrderId = keys["orderId"];
            paymentResponse.Amount = keys["amount"];
            paymentResponse.Mode = keys["mode"];

            if (keys["publicKey"] != null)
                paymentResponse.PublicKey = keys["publicKey"];

            if (keys["errorCode"] != null)
                paymentResponse.Errorcode = keys["errorCode"];

            if (keys["errorMessage"] != null)
                paymentResponse.ErrorMessage = keys["errorMessage"];

            if (keys["transactionDate"] != null)
                paymentResponse.TransactionDate = keys["transactionDate"];

            if (keys["hash"] != null)
                paymentResponse.Hash = keys["hash"];

            if (keys["threeDSecureCode"] != null)
                paymentResponse.ThreeDSecureCode = keys["threeDSecureCode"];

            ValidateResponse(paymentResponse);

            return paymentResponse;
        }

        private bool ValidateResponse(PaymetResponse paymentResponse)
        {
            if (String.IsNullOrEmpty(paymentResponse.Hash))
                throw new Exception("Ödeme cevabı hash bilgisi boş. [result : " + paymentResponse.Result + ",error_code : " + paymentResponse.Errorcode + ",error_message : " + paymentResponse.ErrorMessage + "]");

            string hashText = paymentResponse.OrderId + paymentResponse.Result + paymentResponse.Amount + paymentResponse.Mode + paymentResponse.Errorcode +
               paymentResponse.ErrorMessage + paymentResponse.TransactionDate + this.publicKey + this.privateKey;

            if (IparaRequestUtil.GetSHA1(hashText) != paymentResponse.Hash)
                throw new Exception("Ödeme cevabı hash doğrulaması hatalı. [result : " + paymentResponse.Result + ",error_code : " + paymentResponse.Errorcode + ",error_message : " + paymentResponse.ErrorMessage + "]");

            return true;
        }
    }
}