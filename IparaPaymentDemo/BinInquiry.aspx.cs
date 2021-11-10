using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using System;
using Newtonsoft.Json;

namespace IparaPaymentDemo
{
    public partial class BinInquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binNumber.Value = "492130";
                amount.Value = "1000";
                threeD.Value = "true";
            }
        }


        protected void BtnInquiry_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            BinNumberInquiryRequest request = new();
            request.BinNumber = binNumber.Value;
            request.Amount = amount.Value;
            request.ThreeD = threeD.Value;

            BinNumberInquiryResponse response = BinNumberInquiryRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}