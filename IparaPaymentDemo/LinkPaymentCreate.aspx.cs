using System;
using IparaPayment;
using IparaPayment.Request;
using IparaPayment.Response;
using Newtonsoft.Json;

namespace IparaPaymentDemo
{
    public partial class LinkPaymentCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                name.Value = "Fatih";
                surname.Value = "Coşkun";
                email.Value = "fatih@domain.com";
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
            Settings settings = new();
            LinkPaymentCreateRequest request = new();
            request.Name = name.Value;
            request.Surname = surname.Value;
            request.TcCertificate = tcCertificate.Value;
            request.TaxNumber = taxNumber.Value;
            request.Email = email.Value;
            request.Gsm = gsm.Value;
            request.Amount = Convert.ToInt32(amount.Value);
            request.ThreeD = threeD.Value;
            request.ExpireDate = year.Value + "-" + month.Value + "-" + day.Value + " 23:59:59";
            request.SendEmail = sendEmail.Value;
            request.CommissionType = commissionType.Value;
            request.ClientIp = "127.0.0.1";

            LinkPaymentCreateResponse response = LinkPaymentCreateRequest.Execute(request, settings);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
        }
    }
}