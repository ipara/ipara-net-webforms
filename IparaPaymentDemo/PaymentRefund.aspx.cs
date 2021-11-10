using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using System;
using Newtonsoft.Json;

namespace IparaPaymentDemo
{
    public partial class PaymentRefund : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OrderId.Value = "1550972096";
                RefundHash.Value = "006AYs42lD0p8nCbvU5FrPT3+8lOxScCAkuI1K9QedwXfWl9rA6DO0kwPorCpaIDmqe";
                Amount.Value = "1000";
            }
        }

        protected void BtnRefundInquiry_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            PaymentRefundRequest request = new();
            request.OrderId = OrderId.Value;
            request.RefundHash = RefundHash.Value;
            request.Amount = Amount.Value;
            request.ClientIp = "127.0.0.1";

            PaymentRefundResponse response = PaymentRefundRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}