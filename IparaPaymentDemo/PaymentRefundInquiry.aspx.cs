using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using System;
using Newtonsoft.Json;

namespace IparaPaymentDemo
{
    public partial class PaymentRefundInquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OrderId.Value = "1550972096";
                Amount.Value = "1000";
            }
        }

        protected void BtnRefundInquiry_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            PaymentRefundInquiryRequest request = new();
            request.OrderId = OrderId.Value;
            request.Amount = Amount.Value;
            request.ClientIp = "127.0.0.1";

            PaymentRefundInquiryResponse response = PaymentRefundInquiryRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}