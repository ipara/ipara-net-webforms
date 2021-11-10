using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IparaPayment.Entity
{
    /// <summary>
    /// 
    /// </summary> 
    public class InstallmentDetail
    {
        public string requiredAmount { get; set; }

        public string requiredCommissionAmount { get; set; }

        public string installmentDetail { get; set; }

        public string commissionAmount { get; set; }

        public string merchantCommissionRate { get; set; }

        public string commissionAmountTransient { get; set; }

        public string requiredAmountTransient { get; set; }

        public string merchantCommissionRateTransient { get; set; }

        public string requiredCommissionAmountTransient { get; set; }
    }
}