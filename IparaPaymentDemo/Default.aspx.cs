using System;
using System.Collections.Generic;
using IparaPayment;
using IparaPayment.Entity;
using IparaPayment.Request;

namespace IparaPaymentDemo
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cardOwnerName.Value = "Fatih Coşkun";
                cardNumber.Value = "5456165456165454";
                cardExpireMonth.Value = "12";
                cardExpireYear.Value = "24";
                cardCvc.Value = "000";
                amount.Value = "10000";
            }
        }

        protected void BtnApi3DPaymentInOneStep_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            ThreeDPaymentRequest request = new();
            request.OrderId = Guid.NewGuid().ToString();
            request.Echo = "Echo";
            request.Mode = settings.Mode;
            request.Version = settings.Version;
            request.Amount = amount.Value;
            request.CardOwnerName = cardOwnerName.Value;
            request.CardNumber = cardNumber.Value;
            request.CardExpireMonth = cardExpireMonth.Value;
            request.CardExpireYear = cardExpireYear.Value;
            request.Installment = installment.Value;
            request.Cvc = cardCvc.Value;
            request.CardId = "";
            request.UserId = "";
            request.Language = "tr-TR";

            request.Purchaser = new Purchaser();
            request.Purchaser.Name = "Murat";
            request.Purchaser.SurName = "Kaya";
            request.Purchaser.BirthDate = "1986-07-11";
            request.Purchaser.Email = "murat@kaya.com";
            request.Purchaser.GsmPhone = "5881231212";
            request.Purchaser.IdentityNumber = "12345678901";
            request.Purchaser.ClientIp = "127.0.0.1";

            request.Products = new List<Product>();
            Product p = new();
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

            request.SuccessUrl = "https://apitest.ipara.com/rest/payment/threed/test/result";
            request.FailUrl = "https://apitest.ipara.com/rest/payment/threed/test/result";

            var form = ThreeDPaymentRequest.Execute(request, settings);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();
        }
    }
}