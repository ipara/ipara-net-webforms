using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using Newtonsoft.Json;
using System;

namespace IparaPaymentDemo
{
    public partial class LinkPaymentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            email.Value = "fatih@domain.com";
        }

        protected void BtnListLinkPayment_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            LinkPaymentListRequest request = new();
            request.Email = email.Value;
            request.Gsm = gsm.Value;
            request.LinkState = linkState.Value != "-1" ? linkState.Value : null;

            if (!String.IsNullOrEmpty(linkId.Value))
            {
                request.LinkId = linkId.Value;
            }
            request.StartDate = null;
            request.EndDate = null;
            if (start_year.Value != "" && start_month.Value != "" && start_day.Value != "")
            {
                request.StartDate = start_year.Value + "-" + start_month.Value + "-" + start_day.Value + " 00:00:00";
            }
            if (end_year.Value != "" && end_month.Value != "" && end_day.Value != "")
            {
                request.EndDate = end_year.Value + "-" + end_month.Value + "-" + end_day.Value + " 00:00:00";
            }
            request.PageSize = pageSize.Value;
            request.PageIndex = pageIndex.Value;
            request.ClientIp = "127.0.0.1";

            LinkPaymentListResponse response = LinkPaymentListRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}