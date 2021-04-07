using IparaPayment;
using IparaPayment.Entity;
using IparaPayment.Request;
using IparaPayment.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                if (Request.Form["orderId"] != null)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<pre>Result: " + ((Request.Form["result"] == "1") ? "3D Ödeme Başarılı" : "3D Ödeme Başarısız"));
                    builder.Append("<br/>");
                    builder.Append("Order Id: " + Request.Form["orderId"]);
                    builder.Append("<br/>");
                    builder.Append("Error Code: " + Request.Form["errorCode"]);
                    builder.Append("<br/>");
                    builder.Append("Error Message: " + Request.Form["errorMessage"]);
                    builder.Append("<br/>");
                    builder.Append("ThreeDSecureCode: " + Request.Form["threeDSecureCode"] + "</pre>");

                    result.InnerHtml = builder.ToString();
                }
            }

        }

        protected void BtnApi3DPaymentInOneStep_Click(object sender, EventArgs e)
        {
            IparaPayment.Settings settings = new IparaPayment.Settings();
            var request = new ThreeDPaymentInOneStepRequest();
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
            request.Language = "tr-TR";

            request.Purchaser = new Purchaser
            {
                Name = "Murat",
                SurName = "Kaya",
                Email = "murat@kaya.com",
                ClientIp = "127.0.0.1",
                BirthDate = "1980-07-29"
            };

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

            request.SuccessUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/Api3DPaymentInOneStep.aspx"; // "http://www.magazaniz.com/demo.aspx?type=response&three_d_response=success";
            request.FailUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/Api3DPaymentInOneStep.aspx";  //"http://www.magazaniz.com/demo.aspx?type=response&three_d_response=failure";

            var form = ThreeDPaymentInOneStepRequest.Execute(request, settings);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();


        }
    }
}