using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IparaPayment;
using IparaPayment.Payment.Ipara;
using IparaPayment.Payment.Ipara.Entity;
using IparaPayment.Request;

namespace IparaPaymentDemo
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                nameSurname.Value = "Kart Sahibi Ad Soyad";
                cardNumber.Value = "5456165456165454";
                month.Value = "12";
                year.Value = "24";
                cvc.Value = "000";

            } 
        }

        /*private IparaAuth LoadPayment()
        {
            
            IparaAuth auth = new IparaAuth();

            #region Kart bilgileri

            decimal sumAmount = (decimal.Parse(tbProductPrice1.Text) * int.Parse(tbProductQuatity1.Text)) + (decimal.Parse(tbProductPrice2.Text) * int.Parse(tbProductQuatity2.Text));

            auth.OrderId = lblOrderId.Text;
            auth.Amount = String.Format("{0:0.00}", sumAmount).Replace(".", "").Replace(",", "");
            auth.CardOwnerName = tbCardOwnerName.Text;
            auth.CardNumber = tbCardNumber.Text;
            auth.CardExpireMonth = tbCardExpireMonth.Text;
            auth.CardExpireYear = tbCardExpireYear.Text;
            auth.Installment = tbInstallment.Text;
            auth.Cvc = tbCvc.Text;
            auth.Mode = this.mode;
            // auth.VendorId = this.vendorId;
            auth.Echo = "Echo Bilgisi";

            #endregion

            #region Sipariş veren bilgileri

            tbPurchaserName.Text = "Murat";
            tbPurchaserSurName.Text = "Kaya";
            tbPurchaserBirthDate.Text = "1986-07-11";
            tbPurchaserEmail.Text = "murat@kaya.com";
            tbPurchaserGsmPhone.Text = "5881231212";
            tbPurchaserIdentityNumber.Text = "1234567890";

            #endregion

            #region Sipariş veren bilgileri

            auth.Purchaser = new Purchaser();
            auth.Purchaser.Name = tbPurchaserName.Text;
            auth.Purchaser.SurName = tbPurchaserSurName.Text;
            auth.Purchaser.BirthDate = DateTime.Parse(tbPurchaserBirthDate.Text).ToString("yyyy-MM-dd");
            auth.Purchaser.Email = tbPurchaserEmail.Text;
            auth.Purchaser.GsmPhone = tbPurchaserGsmPhone.Text;
            auth.Purchaser.IdentityNumber = tbPurchaserIdentityNumber.Text;
            auth.Purchaser.ClientIp = Request.UserHostAddress;

            #endregion

            #region Fatura bilgileri

            auth.Purchaser.InvoiceAddress = new PurchaserAddress();
            auth.Purchaser.InvoiceAddress.Name = tbInvoiceName.Text;
            auth.Purchaser.InvoiceAddress.SurName = tbInvoiceSurName.Text;
            auth.Purchaser.InvoiceAddress.Address = tbInvoiceAddress.Text;
            auth.Purchaser.InvoiceAddress.ZipCode = tbInvoiceZipCode.Text;
            auth.Purchaser.InvoiceAddress.CityCode = tbInvoiceCityCode.Text;
            auth.Purchaser.InvoiceAddress.IdentityNumber = tbInvoiceIdentityNumber.Text;
            auth.Purchaser.InvoiceAddress.CountryCode = lblInvoiceCountryCode.Text;
            auth.Purchaser.InvoiceAddress.TaxNumber = tbInvoiceTaxNumber.Text;
            auth.Purchaser.InvoiceAddress.TaxOffice = tbInvoiceTaxOffice.Text;
            auth.Purchaser.InvoiceAddress.CompanyName = tbInvoiceCompanyName.Text;
            auth.Purchaser.InvoiceAddress.PhoneNumber = tbInvoicePhone.Text;

            #endregion

            #region Kargo Adresi bilgileri

            auth.Purchaser.ShippingAddress = new PurchaserAddress();
            auth.Purchaser.ShippingAddress.Name = tbShippingName.Text;
            auth.Purchaser.ShippingAddress.SurName = tbShippingSurName.Text;
            auth.Purchaser.ShippingAddress.Address = tbShippingAddress.Text;
            auth.Purchaser.ShippingAddress.ZipCode = tbShippingZipCode.Text;
            auth.Purchaser.ShippingAddress.CityCode = tbShippingCityCode.Text;
            auth.Purchaser.ShippingAddress.CountryCode = lblShippingCountryCode.Text;
            auth.Purchaser.ShippingAddress.PhoneNumber = tbShippingPhone.Text;

            #endregion

            #region Ürün bilgileri

            auth.Products = new List<Product>();
            Product p = new Product();
            p.Title = tbProductTitle1.Text;
            p.Code = tbProductCode1.Text;
            p.Price = String.Format("{0:0.00}", (decimal.Parse(tbProductPrice1.Text))).Replace(".", "").Replace(",", ""); ;
            p.Quantity = int.Parse(tbProductQuatity1.Text);
            auth.Products.Add(p);
            p = new Product();
            p.Title = tbProductTitle2.Text;
            p.Code = tbProductCode2.Text;
            p.Price = String.Format("{0:0.00}", (decimal.Parse(tbProductPrice2.Text))).Replace(".", "").Replace(",", ""); ;
            p.Quantity = int.Parse(tbProductQuatity2.Text);
            auth.Products.Add(p);

            #endregion

            return auth;
           
        }*/

        protected void btnPay_Click(object sender, EventArgs e)
        {
            /*
            IparaRequest request = new IparaRequest(publicKey, privateKey);
            IparaAuth auth = LoadPayment();

            try
            {
                // Odeme bilgileri API ile odeme servisine iletilir.
                var response = request.Pay(auth);

                if (response.Result.Equals("1"))
                {
                    lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARILI";
                }
                else
                {
                    lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARISIZ. Error Kodu: " + response.Errorcode + " Error Mesajı: " + response.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARISIZ. Error: " + ex.Message;
            }
            */
        }

        protected void btnThreeD_Click(object sender, EventArgs e)
        {
            /*
            IparaRequest request = new IparaRequest(publicKey, privateKey);
            IparaAuth auth = LoadPayment();

            try
            {
                Session["Ipara-Auth"] = auth;
                string successUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThreeDResult.aspx"; // "http://www.magazaniz.com/demo.aspx?type=response&three_d_response=success";
                string failureUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThreeDResult.aspx";  //"http://www.magazaniz.com/demo.aspx?type=response&three_d_response=failure";
                request.PayThreeD(auth, successUrl, failureUrl);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARISIZ. Error: " + ex.Message;
            }
            */
        }

        protected void BtnPay3D_Click(object sender, EventArgs e)
        {
            //3d iki aşamalı bir işlemdir. İlk adımda 3D güvenlik sorgulaması yapılmalıdır. 
            IparaPayment.Settings settings = new IparaPayment.Settings();
            var request = new ThreeDPaymentInitRequest();
            request.OrderId = Guid.NewGuid().ToString();
            request.Echo = "Echo";
            request.Mode = settings.Mode;
            request.Version = settings.Version;
            request.Amount = "10000"; // 100 tL
            request.CardOwnerName = nameSurname.Value;
            request.CardNumber = cardNumber.Value;
            request.CardExpireMonth = month.Value;
            request.CardExpireYear = year.Value;
            request.Installment = installment.Value;
            request.Cvc = cvc.Value;
            request.CardId = "";
            request.UserId = "";


            request.PurchaserName = "Murat";
            request.PurchaserSurname = "Kaya";
            request.PurchaserEmail = "murat@kaya.com";

            string successUrl = 
            request.SuccessUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThreeDResult.aspx"; // "http://www.magazaniz.com/demo.aspx?type=response&three_d_response=success";
            request.FailUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThreeDResult.aspx";  //"http://www.magazaniz.com/demo.aspx?type=response&three_d_response=failure";

            var form = ThreeDPaymentInitRequest.Execute(request, settings);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();
        }
    }
}