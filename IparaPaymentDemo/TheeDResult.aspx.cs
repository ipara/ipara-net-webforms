using IparaPayment.Payment.Ipara;
using IparaPayment.Payment.Ipara.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IparaPaymentDemo
{
    public partial class TheeDResult : System.Web.UI.Page
    {
        private string publicKey = Settings.PublicKey;
        private string privateKey = Settings.PrivateKey;
        private string vendorId = Settings.VendorId;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                IparaRequest payment = new IparaRequest(publicKey, privateKey);
                PaymetResponse response = payment.GetThreeDResponse(Request.Form);

                if (response == null)
                {
                    lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARISIZ";
                    return;
                }

                if (response.Result.Equals("1"))
                {
                    if (Session["Ipara-Auth"] == null)
                    {
                        lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARISIZ. Session bulunamadı.";
                        return;
                    }

                    IparaAuth auth = Session["Ipara-Auth"] as IparaAuth;
                    auth.ThreeDSecureCode = response.ThreeDSecureCode;
                    auth.Echo = "Echo Bilgisi";
                    auth.VendorId = this.vendorId;

                    response = payment.PayThreeDResult(auth);

                    if (response == null)
                    {
                        lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARISIZ. Response boş.";
                        return;
                    }

                    if (response.Result.Equals("1"))
                    {
                        lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARILI";
                    }
                    else
                    {
                        lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARISIZ. Error Kodu: " + response.Errorcode + " Error Mesajı: " + response.ErrorMessage;
                    }
                }
                else
                {
                    lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARISIZ. Error Kodu: " + response.Errorcode + " Error Mesajı: " + response.ErrorMessage;
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "ÖDEME İŞLEMİNİZ BAŞARISIZ";
            }
        }
    }
}