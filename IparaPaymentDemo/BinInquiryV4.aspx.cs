using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using System;
using Newtonsoft.Json;
using IPara.DeveloperPortal.Core.Response;
using IPara.DeveloperPortal.Core.Request;

namespace IparaPaymentDemo
{
    public partial class BinInquiryV4 : System.Web.UI.Page
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
            BinNumberInquiryV4Request request = new();
            request.BinNumber = binNumber.Value;
            request.Amount = amount.Value;
            request.ThreeD = threeD.Value;

            BinNumberInquiryV4Response response = BinNumberInquiryV4Request.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}