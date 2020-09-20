using IparaPayment;
using IparaPayment.Payment.Ipara.Entity;
using IparaPayment.Request;
using IparaPayment.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IparaPaymentDemo
{
    public partial class ThreeDResult1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ThreeDPaymentInitResponse paymentResponse = new ThreeDPaymentInitResponse();
            paymentResponse.OrderId = Request.Form["orderId"];
            paymentResponse.Result = Request.Form["result"];
            paymentResponse.Amount = Request.Form["amount"];
            paymentResponse.Mode = Request.Form["mode"];
            
            if (Request.Form["errorCode"] != null)
                paymentResponse.ErrorCode = Request.Form["errorCode"];

            if (Request.Form["errorMessage"] != null)
                paymentResponse.ErrorMessage = Request.Form["errorMessage"];

            if (Request.Form["transactionDate"] != null)
                paymentResponse.TransactionDate = Request.Form["transactionDate"];

            if (Request.Form["hash"] != null)
                paymentResponse.Hash = Request.Form["hash"];

            Settings settings = new Settings();

            if (Helper.Validate3DReturn(paymentResponse, settings))
            {
                var request = new ThreeDPaymentCompleteRequest();

                #region Request New
                request.OrderId = Request.Form["orderId"];
                request.Echo = "Echo";
                request.Mode = settings.Mode;
                request.Amount = "10000"; // 100 tL
                request.CardOwnerName = "Fatih Coşkun";
                request.CardNumber = "4282209027132016";
                request.CardExpireMonth = "05";
                request.CardExpireYear = "18";
                request.Installment = "1";
                request.Cvc = "000";
                request.ThreeD = "true";
                request.ThreeDSecureCode = Request.Form["threeDSecureCode"];
                #endregion

                #region Sipariş veren bilgileri
                request.Purchaser = new Purchaser();
                request.Purchaser.BirthDate = "1986-07-11";
                request.Purchaser.GsmPhone = "5881231212";
                request.Purchaser.IdentityNumber = "1234567890";
                #endregion

                #region Fatura bilgileri
                request.Purchaser.InvoiceAddress = new PurchaserAddress();
                request.Purchaser.InvoiceAddress.Name = "Murat";
                request.Purchaser.InvoiceAddress.SurName = "Kaya";
                request.Purchaser.InvoiceAddress.Address = "Mevlüt Pehlivan Mah. Multinet Plaza Şişli";
                request.Purchaser.InvoiceAddress.ZipCode = "34782";
                request.Purchaser.InvoiceAddress.CityCode = "34";
                request.Purchaser.InvoiceAddress.IdentityNumber = "1234567890";
                request.Purchaser.InvoiceAddress.CountryCode = "TR";
                request.Purchaser.InvoiceAddress.TaxNumber = "123456";
                request.Purchaser.InvoiceAddress.TaxOffice = "Kozyatağı";
                request.Purchaser.InvoiceAddress.CompanyName = "iPara";
                request.Purchaser.InvoiceAddress.PhoneNumber = "2122222222";
                #endregion

                #region Kargo Adresi bilgileri
                request.Purchaser.ShippingAddress = new PurchaserAddress();
                request.Purchaser.ShippingAddress.Name = "Murat";
                request.Purchaser.ShippingAddress.SurName = "Kaya";
                request.Purchaser.ShippingAddress.Address = "Mevlüt Pehlivan Mah. Multinet Plaza Şişli";
                request.Purchaser.ShippingAddress.ZipCode = "34782";
                request.Purchaser.ShippingAddress.CityCode = "34";
                request.Purchaser.ShippingAddress.IdentityNumber = "1234567890";
                request.Purchaser.ShippingAddress.CountryCode = "TR";
                request.Purchaser.ShippingAddress.PhoneNumber = "2122222222";
                #endregion

                #region Ürün bilgileri
                request.Products = new List<Product>();
                Product p = new Product();
                p.Title = "Telefon";
                p.Code = "TLF0001";
                p.Price = "5000";
                p.Quantity = 1;
                request.Products.Add(p);
                p = new Product();
                p.Title = "Bilgisayar";
                p.Code = "BLG0001";
                p.Price = "5000";
                p.Quantity = 1;
                request.Products.Add(p);
                #endregion

                var response = ThreeDPaymentCompleteRequest.Execute(request, settings);
                string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
                lblMessage.Text = (paymentResponse.Result == "1") ? "3D Ödeme Başarılı" : "3D Ödeme Başarısız";
                result.InnerHtml = "<pre>" + jsonResponse + "</pre>";

            }
            
        }
    }
}