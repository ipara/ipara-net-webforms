using IparaPayment.Entity;
using IparaPayment.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IparaPayment.Response
{
    public class LinkPaymentDeleteResponse : BaseResponse
    {
     public List<PaymentLink> linkPaymentRecordList { get; set; }

     public string pageIndex { get; set; }
     public string pageSize { get; set; }
     public string pageCount { get; set; }

    }
}
