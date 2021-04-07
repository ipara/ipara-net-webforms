using IparaPayment;
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
    public partial class AddCardToWallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId.Value = "123456";
                nameSurname.Value = "Kart Sahibi Ad Soyad";
                cardNumber.Value = "5456165456165454";
                cardAlias.Value = "Maas Karti";
                month.Value = "12";
                year.Value = "24";
            }
            

        }

        protected void BtnAddCardToWallet_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            BankCardCreateRequest request = new BankCardCreateRequest();
            request.userId = userId.Value;
            request.cardOwnerName = nameSurname.Value;
            request.cardNumber = cardNumber.Value;
            request.cardAlias = cardAlias.Value;
            request.cardExpireMonth = month.Value;
            request.cardExpireYear = year.Value;
            request.clientIp = "127.0.0.1";
            BankCardCreateResponse response = BankCardCreateRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";

            //   return View();
        }
    }
}