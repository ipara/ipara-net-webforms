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
    public class IparaRequest
    {
        private string _authUrl = "https://api.ipara.com/rest/payment/auth";
        private string _threeDUrl = "https://www.ipara.com/3dgate";
        private string _version = "1.0";

        private string _privateKey { get; set; }
        private string _publicKey { get; set; }

        public IparaRequest(string publicKey, string privateKey)
        {
            this._privateKey = privateKey;
            this._publicKey = publicKey;
        }

        // API ile Odeme Metodu
        public PaymetResponse Pay(IparaAuth auth)
        {
            auth.ThreeD = "false";
            string xmlData = IparaRequestUtil.SerializeObject(auth);

            if (!string.IsNullOrEmpty(xmlData))
            {
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string hashText = this._privateKey + auth.OrderId + auth.Amount + auth.Mode + auth.CardOwnerName +
                   auth.CardNumber + auth.CardExpireMonth + auth.CardExpireYear + auth.Cvc + auth.Purchaser.Name + auth.Purchaser.SurName + auth.Purchaser.Email + dateTime;

                string token = this._publicKey + ":" + IparaRequestUtil.GetSHA1(hashText);

                string response = IparaRequestUtil.ApiRequest(token, this._version, dateTime, xmlData, this._authUrl);

                PaymetResponse paymentResponse = IparaRequestUtil.DeserializeObject<PaymetResponse>(response);

                ValidateResponse(paymentResponse);

                return paymentResponse;
            }
            else
                throw new Exception("Ödeme isteği gönderilirken beklenmedik bir hata oluştu!");
        }

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

                string hashText = this._privateKey + auth.OrderId + auth.Amount + auth.Mode + auth.ThreeDSecureCode + dateTime;

                string token = this._publicKey + ":" + IparaRequestUtil.GetSHA1(hashText);

                string response = IparaRequestUtil.ApiRequest(token, this._version, dateTime, xmlData, this._authUrl);

                PaymetResponse paymentResponse = IparaRequestUtil.DeserializeObject<PaymetResponse>(response);

                ValidateResponse(paymentResponse);

                return paymentResponse;
            }
            else
                throw new Exception("Ödeme isteği gönderilirken beklenmedik bir hata oluştu!");
        }

        //3D Secure ile Odeme Methodu
        public void PayThreeD(IparaAuth auth, String successUrl, String failureUrl)
        {
            auth.ThreeD = "true";

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string hashText = this._privateKey + auth.OrderId + auth.Amount + auth.Mode + auth.CardOwnerName +
               auth.CardNumber + auth.CardExpireMonth + auth.CardExpireYear + auth.Cvc + auth.Purchaser.Name + auth.Purchaser.SurName + auth.Purchaser.Email + dateTime;

            string token = this._publicKey + ":" + IparaRequestUtil.GetSHA1(hashText);

            StringBuilder builder = new StringBuilder();

            builder.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            builder.Append("<html>");
            builder.Append("<body>");
            builder.Append("<form action=\"" + this._threeDUrl + "\" method=\"post\" id=\"three_d_form\"/>");
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
            builder.Append("<input type=\"hidden\" name=\"version\" value=\"" + this._version + "\"/>");
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
               paymentResponse.ErrorMessage + paymentResponse.TransactionDate + this._publicKey + this._privateKey;

            if (IparaRequestUtil.GetSHA1(hashText) != paymentResponse.Hash)
                throw new Exception("Ödeme cevabı hash doğrulaması hatalı. [result : " + paymentResponse.Result + ",error_code : " + paymentResponse.Errorcode + ",error_message : " + paymentResponse.ErrorMessage + "]");

            return true;
        }
    }
}