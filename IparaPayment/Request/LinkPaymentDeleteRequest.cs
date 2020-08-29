using IparaPayment.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IparaPayment.Request
{
    public class LinkPaymentDeleteRequest : BaseRequest
    {
        public string linkId { get; set; }
        public string clientIp { get; set; }
        public static BaseResponse Execute(LinkPaymentDeleteRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.clientIp + options.TransactionDate;
            BaseResponse response = RestHttpCaller.Create().PostJson<BaseResponse>(options.BaseUrl + "corporate/merchant/linkpayment/delete", Helper.GetHttpHeaders(options, Helper.application_json), request);
            return response;
        }
    }
}
