using System;
using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace IparaPaymentDemo
{
    public partial class LinkPaymentCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                name.Value = "Müşteri Ad";
                surname.Value = "Müşteri Soyad";
                email.Value = "mail@example.com";
                gsm.Value = "5881231212";
                DateTime moment = DateTime.Now;
                year.Value = moment.Year.ToString();
                month.Value = moment.Month.ToString();
                day.Value = moment.Day.ToString();
                amount.Value = "1000";

            }


        }

        protected void BtnCreateLinkPayment_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            LinkPaymentCreateRequest request = new LinkPaymentCreateRequest();
            request.name = name.Value;
            request.surname = surname.Value;
            request.tcCertificate = tcCertificate.Value;
            request.taxNumber = taxNumber.Value;
            request.email = email.Value;
            request.gsm = gsm.Value;
            request.amount = Convert.ToInt32(amount.Value);
            request.threeD = threeD.Value;
            request.expireDate = year.Value + "-" + month.Value + "-" + day.Value + " 23:59:59";
            int[] i = new int[1];
            i[0] = Convert.ToInt32(installmentList.Value);
            request.installmentList = i;
            request.sendEmail = sendEmail.Value;
            request.commissionType = commissionType.Value;
            request.clientIp = "127.0.0.1";

            LinkPaymentCreateResponse response = LinkPaymentCreateRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}