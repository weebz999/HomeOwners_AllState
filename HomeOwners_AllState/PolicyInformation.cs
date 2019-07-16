﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeOwners_AllState
{
   public class PolicyInformation
    {
        public string PolicyType { get; set; }
        public Name NamedInsured{ get; set; }
        public string PolicyNumber { get; set; }
        public DatePeriod PolicyPeriod { get; set; }
        public InsurenceAgency InsurenceAgency { get; set; }
        public string PolicyForm { get; set; }
        public string BillingAccountNumber { get; set; }
        public string PolicyFee { get; set; }
        public Address InsuredAddress { get; set; }


    }
}
