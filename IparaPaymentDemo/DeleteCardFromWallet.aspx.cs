﻿using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using Newtonsoft.Json;
using System;

namespace IparaPaymentDemo
{
    public partial class DeleteCardFromWallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId.Value = "123456";
            }
        }

        protected void BtnDeleteCard_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            BankCardDeleteRequest request = new();
            request.UserId = userId.Value;
            request.CardId = cardId.Value;
            request.ClientIp = "127.0.0.1";

            BankCardDeleteResponse response = BankCardDeleteRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}