using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IparaPayment.Entity
{
    [XmlRoot(ElementName = "authResponse")]
    public class PaymetResponse
    {
        [XmlElement("errorCode")]
        public string Errorcode { get; set; }

        [XmlElement("errorMessage")]
        public string ErrorMessage { get; set; }

        [XmlElement("amount")]
        public string Amount { get; set; }

        [XmlElement("hash")]
        public string Hash { get; set; }

        [XmlElement("mode")]
        public string Mode { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        [XmlElement("publicKey")]
        public string PublicKey { get; set; }

        [XmlElement("result")]
        public string Result { get; set; }

        [XmlElement("transactionDate")]
        public string TransactionDate { get; set; }
        
        public string ThreeDSecureCode { get; set; }
    }
}
