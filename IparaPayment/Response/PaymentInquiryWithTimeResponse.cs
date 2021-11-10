using System.Collections.Generic;
using IparaPayment.Entity;

namespace IparaPayment.Response
{
    /// <summary>
    ///  Girilen tarih aralığında bulunan ödemeleri sorgulama servisi sonucunda oluşan çıktı parametrelerini temsil eder.
    /// </summary>
    public class PaymentInquiryWithTimeResponse : BaseResponse
    {
        public List<Payment> payments;

        public string totalPayments;
    }
}
