using IparaPayment.Entity;
using IparaPayment.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IparaPayment.Request
{
    public class ThreeDPaymentInOneStepRequest : BaseRequest
    {
        public string orderId { get; set; }
        public string cardOwnerName { get; set; }
        public string cardNumber { get; set; }
        public string cardExpireMonth { get; set; }
        public string cardExpireYear { get; set; }
        public string cardCvc { get; set; }
        public string userId { get; set; }
        public string cardId { get; set; }
        public string installment { get; set; }
        public string amount { get; set; }
        public string successUrl { get; set; }
        public string failureUrl { get; set; }
        public string version { get; set; }

        public string transactionDate { get; set; }

        public string token { get; set; }

        public List<Product> products { get; set; }
        public Purchaser purchaser { get; set; }

        public static ThreeDPaymentCompleteResponse Execute(ThreeDPaymentInOneStepRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.orderId + request.amount + request.Mode + request.cardOwnerName + request.cardNumber + request.cardExpireMonth + request.cardExpireYear + request.cardCvc + request.userId + request.cardId + request.purchaser.Name + request.purchaser.SurName + request.purchaser.Email + options.TransactionDate;
            ThreeDPaymentCompleteResponse response = RestHttpCaller.Create().PostJson<ThreeDPaymentCompleteResponse>(options.BaseUrl + "rest/payment/threed", Helper.GetHttpHeaders(options, Helper.application_json), request);
            return response;
        }

    }
}
