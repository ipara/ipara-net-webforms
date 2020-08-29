using IparaPayment;
using IparaPayment.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IparaPaymentDemo
{
    public partial class LinkPaymentDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnDeleteLinkPayment_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            LinkPaymentDeleteRequest request = new LinkPaymentDeleteRequest();
            request.linkId = linkId.Value;
            request.clientIp = "127.0.0.1";

            BaseResponse response = LinkPaymentDeleteRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}