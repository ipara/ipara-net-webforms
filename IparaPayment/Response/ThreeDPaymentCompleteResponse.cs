﻿using IparaPayment.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IparaPayment.Response
{
    /// <summary>
    ///  3D Secure ile ödeme 2. adımı sonucunda oluşan servis çıktı parametrelerini temsil etmektedir.
    /// </summary>
    [XmlRoot("authResponse")]
    public class ThreeDPaymentCompleteResponse : BaseResponse
    {
        [JsonProperty("amount")]
        [XmlElement("amount")]
        public string Amount { get; set; }

        [JsonProperty("orderId")]
        [XmlElement("orderId")]
        public string OrderId { get; set; }
    }
}
