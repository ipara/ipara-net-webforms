﻿using IparaPayment.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IparaPayment.Response
{
    public class PaymentRefundResponse : BaseResponse
    {
        public string amount { get; set; }
    }
}