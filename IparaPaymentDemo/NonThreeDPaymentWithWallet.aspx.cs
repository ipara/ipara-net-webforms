using IparaPayment;
using IparaPayment.Entity;
using IparaPayment.Request;
using IparaPayment.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IparaPaymentDemo
{
    public partial class NonThreeDPaymentWithWallet : System.Web.UI.Page
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
            Settings settings = new();
            Non3DPaymentRequest request = new();
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

            request.Purchaser = new Purchaser();
            request.Purchaser.Name = "Murat";
            request.Purchaser.SurName = "Kaya";
            request.Purchaser.BirthDate = "1986-07-11";
            request.Purchaser.Email = "murat@kaya.com";
            request.Purchaser.GsmPhone = "5881231212";
            request.Purchaser.IdentityNumber = "1234567890";
            request.Purchaser.ClientIp = "127.0.0.1";

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

            request.Purchaser.ShippingAddress = new PurchaserAddress();
            request.Purchaser.ShippingAddress.Name = "Murat";
            request.Purchaser.ShippingAddress.SurName = "Kaya";
            request.Purchaser.ShippingAddress.Address = "Mevlüt Pehlivan Mah. Multinet Plaza Şişli";
            request.Purchaser.ShippingAddress.ZipCode = "34782";
            request.Purchaser.ShippingAddress.CityCode = "34";
            request.Purchaser.ShippingAddress.IdentityNumber = "1234567890";
            request.Purchaser.ShippingAddress.CountryCode = "TR";
            request.Purchaser.ShippingAddress.PhoneNumber = "2122222222";

            request.Products = new List<Product>();
            Product p = new();
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

            Non3DPaymentResponse response = Non3DPaymentRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}