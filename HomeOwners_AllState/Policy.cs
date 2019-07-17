using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeOwners_AllState
{
   public class Policy
    {
        public string PolicyType { get; set; }
        public List<Name> NamesInsured { get; set; } = new List<Name>();
        public string PolicyNumber { get; set; }
        public DatePeriod PolicyPeriod { get; set; } = new DatePeriod();
        public InsurenceAgency InsurenceAgency { get; set; } = new InsurenceAgency();
        public string PolicyForm { get; set; }
        public string BillingAccountNumber { get; set; }
        public string PolicyFee { get; set; }
        public Address InsuredAddress { get; set; } = new Address();
        public DatePeriod PolicyEffectiveDate { get; set; } = new DatePeriod();
        public Deductable Deductable { get; set; } = new Deductable();
        public Coverage Coverage { get; set; } = new Coverage();
        
        public Amount Amount { get; set; } = new Amount();
        public DatePeriod DatePeriod { get; set; } = new DatePeriod();
        public DocumentIdentification DocumentIdentification { get; set; } = new DocumentIdentification();
        public Endorsement Endorsement { get; set; } = new Endorsement();
        public InsuranceCompanyInfo InsuranceCompanyInfo { get; set; } = new InsuranceCompanyInfo();
        public InsuredPropertyDetail InsuredPropertyDetails { get; set; } = new InsuredPropertyDetail();
        public LimitsOfLiability LimitsOfLiability { get; set; } = new LimitsOfLiability();
        public Mortagaee Mortagaee { get; set; } = new Mortagaee();
        public Discount Discount { get; set; } = new Discount();





    }
}
