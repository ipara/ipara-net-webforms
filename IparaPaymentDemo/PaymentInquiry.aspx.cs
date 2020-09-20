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
    public partial class PaymentInquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                orderId.Value = "58e1e9f22690b";
            }
        }

        protected void BtnInquiry_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            PaymentInquiryRequest request = new PaymentInquiryRequest();
            request.orderId = orderId.Value;
            request.Mode = settings.Mode;
            request.Echo = "Echo";
            PaymentInquiryResponse response = PaymentInquiryRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}