using IparaPayment.Response;

namespace IparaPayment.Request
{
    /// <summary>
    ///  İade sorgulama servisi için gerekli olan servis girdi parametrelerini temsil eder.
    /// </summary>
    public class PaymentRefundInquiryRequest : BaseRequest
    {
        public string OrderId { get; set; }

        public string Amount { get; set; }

        public string ClientIp { get; set; }

        /// <summary>
        /// Bu servise sorgulanmak istenen iadenin mağaza sipariş numarası, sipariş tutarı ve clientIp değeri iletilerek, iade durumunun öğrenilebileceği servisi temsil eder.
        /// </summary>
        /// <param name="request">İade sorgulama servisi için gerekli olan girdilerin olduğu sınıfı temsil eder.</param>
        /// <param name="options">Kullanıcıya özel olarak belirlenen ayarları temsil eder.</param>
        /// <returns></returns>
        public static PaymentRefundInquiryResponse Execute(PaymentRefundInquiryRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey + request.OrderId + request.ClientIp + options.TransactionDate;
            return RestHttpCaller.Create()
                .PostJson<PaymentRefundInquiryResponse>(options.BaseUrl + "corporate/payment/refund/inquiry", Helper.GetHttpHeaders(options, Helper.application_json), request);
        }
    }
}