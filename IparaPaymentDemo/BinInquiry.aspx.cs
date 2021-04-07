using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace IparaPaymentDemo
{
    public partial class BinInquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BinNumber.Value = "545616";
            }
        }

        
        protected void BtnInquiry_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            BinNumberInquiryRequest request = new BinNumberInquiryRequest();
            request.binNumber = BinNumber.Value;
            BinNumberInquiryResponse response = BinNumberInquiryRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}