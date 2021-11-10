using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using Newtonsoft.Json;
using System;

namespace IparaPaymentDemo
{
    public partial class AddCardToWallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId.Value = "123456";
                nameSurname.Value = "Fatih Coşkun";
                cardNumber.Value = "4531444531442283";
                cardAlias.Value = "Maas Karti";
                month.Value = "12";
                year.Value = "24";
            }
        }

        protected void BtnAddCardToWallet_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            BankCardCreateRequest request = new();
            request.UserId = userId.Value;
            request.CardOwnerName = nameSurname.Value;
            request.CardNumber = cardNumber.Value;
            request.CardAlias = cardAlias.Value;
            request.CardExpireMonth = month.Value;
            request.CardExpireYear = year.Value;
            request.ClientIp = "127.0.0.1";

            BankCardCreateResponse response = BankCardCreateRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}