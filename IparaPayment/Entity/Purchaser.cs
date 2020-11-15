using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace IparaPayment.Entity
{
    /// <summary>
    /// Bu sınıf 3D secure olmadan ödeme kısmında müşteri bilgilerinin kullanılacağı yerde ve
    ///  3D Secure ile Ödeme'nin 2. adımında müşteri bilgilerinin istendiği yerde kullanılır.
    /// </summary>
    [XmlRoot("purchaser")]
    public class Purchaser
    {
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        [XmlElement("surname")]
        public string SurName { get; set; }

        [JsonProperty("birthDate")]
        [XmlElement("birthDate")]
        public string BirthDate { get; set; }
        
        [JsonProperty("email")]
        [XmlElement("email")]
        public string Email { get; set; }

        [JsonProperty("gsmNumber")]
        [XmlElement("gsmNumber")]
        public string GsmPhone { get; set; }

        [JsonProperty("tcCertificate")]
        [XmlElement("tcCertificate")]
        public string IdentityNumber { get; set; }

        [JsonProperty("clientIp")]
        [XmlElement("clientIp")]
        public string ClientIp { get; set; }

        [JsonProperty("invoiceAddress")]
        [XmlElement("invoiceAddress")]
        public PurchaserAddress InvoiceAddress { get; set; }

        [JsonProperty("shippingAddress")]
        [XmlElement("shippingAddress")]
        public PurchaserAddress ShippingAddress { get; set; }


    }
}