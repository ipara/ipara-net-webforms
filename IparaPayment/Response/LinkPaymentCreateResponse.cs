using IparaPayment.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IparaPayment.Response
{
    public class LinkPaymentCreateResponse : BaseResponse
    {
        public string link { get; set; }
        public string linkPaymentId { get; set; }
        public string amount { get; set; }
    }
}
