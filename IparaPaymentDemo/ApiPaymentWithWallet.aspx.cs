using IparaPayment;
using IparaPayment.Entity;
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
    public partial class ApiPaymentWithWallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId.Value = "123456";
            }
        }

        protected void BtnApiPaymentWithWallet_Click(object sender, EventArgs e)
        {
            var request = new ApiPaymentRequest();
            Settings settings = new Settings();
            #region Request New
            request.OrderId = Guid.NewGuid().ToString();
            request.Echo = "Echo"; // Cevap anında geri gelecek işlemi ayırt etmeye yarayacak alan
            request.Mode = settings.Mode;
            request.Amount = "10000"; // 100.00 tL
            request.CardOwnerName = "";
            request.CardNumber = "";
            request.CardExpireMonth = "";
            request.CardExpireYear = "";
            request.Installment = installment.Value;
            request.Cvc = "";
            request.ThreeD = "false";
            request.CardId = cardId.Value;
            request.UserId = userId.Value;

            #endregion
            //Buradaki bilgilerin sizin tablolarınız veya ekranlarınızdan gelmesi gerekmektedir. 
            #region Sipariş veren bilgileri
            request.Purchaser = new Purchaser();
            request.Purchaser.Name = "Murat";
            request.Purchaser.SurName = "Kaya";
            request.Purchaser.BirthDate = "1986-07-11";
            request.Purchaser.Email = "murat@kaya.com";
            request.Purchaser.GsmPhone = "5881231212";
            request.Purchaser.IdentityNumber = "1234567890";
            request.Purchaser.ClientIp = "127.0.0.1";
            #endregion
            //Buradaki bilgilerin sizin tablolarınız veya ekranlarınızdan gelmesi gerekmektedir. 
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
            //Buradaki bilgilerin sizin tablolarınız veya ekranlarınızdan gelmesi gerekmektedir. 
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
            //Buradaki bilgilerin sizin tablolarınız veya ekranlarınızdan gelmesi gerekmektedir. 
            #region Ürün bilgileri

            request.Products = new List<Product>();
            Product p = new Product();
            p.Title = "Telefon";
            p.Code = "TLF0001";
            p.Price = "5000"; //50.00 TL 
            p.Quantity = 1;
            request.Products.Add(p);
            p = new Product();
            p.Title = "Bilgisayar";
            p.Code = "BLG0001";
            p.Price = "5000"; //50.00 TL 
            p.Quantity = 1;
            request.Products.Add(p);

            ApiPaymentResponse response = ApiPaymentRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";

            #endregion
        }
    }
}