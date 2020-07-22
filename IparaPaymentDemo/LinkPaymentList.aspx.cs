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
    public partial class LinkPaymentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            email.Value = "mail@example.com";

        }

        protected void BtnListLinkPayment_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            LinkPaymentListRequest request = new LinkPaymentListRequest();
            request.email = email.Value;
            request.gsm = gsm.Value;
            request.linkState = linkState.Value != "-1" ? linkState.Value : null;
            request.startDate = null;
            request.endDate = null;
            // request.expireDate = year.Value + "-" + month.Value + "-" + day.Value + " 23:59:59";
            //int[] i = new int[1];
            //i[0] = Convert.ToInt32(installmentList.Value);
            //request.installmentList = i;
            request.pageSize = "5";
            request.pageIndex = "1";
            request.clientIp = "127.0.0.1";

            LinkPaymentListResponse response = LinkPaymentListRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}