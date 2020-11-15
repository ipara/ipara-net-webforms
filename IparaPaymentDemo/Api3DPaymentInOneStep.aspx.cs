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
    public partial class Api3DPaymentWithOneStep : System.Web.UI.Page
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

        protected void BtnApi3DPaymentInOneStep_Click(object sender, EventArgs e)
        {
            IparaPayment.Settings settings = new IparaPayment.Settings();
            var request = new ThreeDPaymentInOneStepRequest();
            request.orderId = Guid.NewGuid().ToString();
            request.Echo = "Echo";
            request.Mode = settings.Mode;
            request.version = settings.Version;
            request.amount = "10000"; // 100 tL
            request.cardOwnerName = nameSurname.Value;
            request.cardNumber = cardNumber.Value;
            request.cardExpireMonth = month.Value;
            request.cardExpireYear = year.Value;
            request.installment = installment.Value;
            request.cardCvc = cvc.Value;
            request.cardId = "";
            request.userId = "";

            request.purchaser = new Purchaser();
            request.purchaser.Name= "Murat";
            request.purchaser.SurName = "Kaya";
            request.purchaser.Email = "murat@kaya.com";
            #region Ürün bilgileri
            
            request.products = new List<Product>();
            Product p = new Product();
            p.Title = "Telefon";
            p.Code = "TLF0001";
            p.Price = "5000";
            p.Quantity = 1;
            request.products.Add(p);
            
            p = new Product();
            p.Title = "Bilgisayar";
            p.Code = "BLG0001";
            p.Price = "5000";
            p.Quantity = 1;
            request.products.Add(p);
            #endregion

            request.successUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThreeDResult.aspx"; // "http://www.magazaniz.com/demo.aspx?type=response&three_d_response=success";
            request.failureUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThreeDResult.aspx";  //"http://www.magazaniz.com/demo.aspx?type=response&three_d_response=failure";

            ThreeDPaymentCompleteResponse response = ThreeDPaymentInOneStepRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";

        }
    }
}