using IparaPayment.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IparaPaymentDemo
{
    public partial class Api3DPaymentWithWallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId.Value = "123456";
            }
        }

        protected void BtnApi3DPaymentWithWallet_Click(object sender, EventArgs e)
        {
            //3d iki aşamalı bir işlemdir. İlk adımda 3D güvenlik sorgulaması yapılmalıdır. 
            IparaPayment.Settings settings = new IparaPayment.Settings();
            var request = new ThreeDPaymentInitRequest();
            request.OrderId = Guid.NewGuid().ToString();
            request.Echo = "Echo";
            request.Mode = settings.Mode;
            request.Version = settings.Version;
            request.Amount = "10000"; // 100 tL
            request.CardId = cardId.Value;
            request.UserId = userId.Value;

            request.PurchaserName = "Murat";
            request.PurchaserSurname = "Kaya";
            request.PurchaserEmail = "murat@kaya.com";

            string successUrl =
            request.SuccessUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThreeDResult.aspx"; // "http://www.magazaniz.com/demo.aspx?type=response&three_d_response=success";
            request.FailUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThreeDResult.aspx";  //"http://www.magazaniz.com/demo.aspx?type=response&three_d_response=failure";

            var form = ThreeDPaymentInitRequest.Execute(request, settings);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(form);
            System.Web.HttpContext.Current.Response.End();
        }
    }
}