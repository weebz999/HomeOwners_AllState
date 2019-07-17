using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace HomeOwners_AllState
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@" E:\Home Owners tasks\Allstate -1 Dec.json");
            JsonHomeOwnersAllState.HomeOwners homeOwners = JsonConvert.DeserializeObject<JsonHomeOwnersAllState.HomeOwners>(json);


            Policy policyInformation = new Policy();
            policyInformation.PolicyForm = homeOwners.CompanyName;
            policyInformation.PolicyNumber = homeOwners.PolicyNumber;


            policyInformation.PolicyEffectiveDate.From = homeOwners.PolicyEffectiveDate.period.From;
            policyInformation.PolicyPeriod.From = homeOwners.PolicyPeriod.Period.From;
            policyInformation.PolicyPeriod.To = homeOwners.PolicyPeriod.Period.To;
            policyInformation.PolicyType = homeOwners.ProviderEntityName;
            policyInformation.PolicyFee = "";
            policyInformation.BillingAccountNumber = "";



            // DocumentIdentification start

            policyInformation.DocumentIdentification.CompanyName = homeOwners.CompanyName;
            policyInformation.DocumentIdentification.FormIdentifier = homeOwners.FormIdentifier;
            policyInformation.DocumentIdentification.FormName = homeOwners.FormName;

            //End DocumentIdentification


            //Start NamedInsured
            foreach (var getName in homeOwners.NamedInsured.Name)
            {
                policyInformation.NamesInsured.Add(new Name
                {
                    FirstName = getName.FirstName,
                    MiddleName = getName.MiddleName,
                    LastName = getName.LastName,
                    Title = (string)getName.Title

                });

            }
            // End of NamedInsured

            

            //start of InsuredAddress 

            policyInformation.InsuredAddress.AddressLine1 = homeOwners.MailingAddress.AddressLine1;
            policyInformation.InsuredAddress.AddressLine2 = (string)homeOwners.MailingAddress.AddressLine2;
            policyInformation.InsuredAddress.City = homeOwners.MailingAddress.City;
            policyInformation.InsuredAddress.State = homeOwners.MailingAddress.State;
            policyInformation.InsuredAddress.ZipCode = homeOwners.MailingAddress.ZipCode;
            policyInformation.InsuredAddress.FullAddress = homeOwners.MailingAddress.FullAddress;

            //End of Address values

            //start of Amount 

            policyInformation.Amount.Value = homeOwners.TotalPremium;
            policyInformation.Amount.ValueType = "";

            //End Of Amount class

            //start of limitofliability
            foreach (var liability in homeOwners.CoverageDetails)
            {
                policyInformation.LimitsOfLiability.Occurance = "";
                policyInformation.LimitsOfLiability.PayableType = "";
                policyInformation.LimitsOfLiability.Value = liability.LimitsOfLiability;
                policyInformation.LimitsOfLiability.ValueType = "Amount";
            }

            // end of limitofliability


            // Start of Dedcutable class

            foreach (var dedcuctablename in homeOwners.CoverageDetails)
            {
                policyInformation.Deductable.Name = dedcuctablename.ApplicableDeductibles;
                policyInformation.Deductable.Section = dedcuctablename.Coverage;
                policyInformation.Deductable.Code = homeOwners.FormIdentifier;
                policyInformation.Deductable.TotalAmount.Value = dedcuctablename.LimitsOfLiability;
                policyInformation.Deductable.TotalAmount.ValueType = "Amount";
                policyInformation.Deductable.AdditionalInformation = "None";

            }


            //End of Dedcutable


            // start of coverage class object
            foreach (var coveragename in homeOwners.CoverageDetails)
            {

                policyInformation.Coverage.Name = coveragename.Coverage;
                policyInformation.Coverage.Code = "";
                policyInformation.Coverage.Section = "";

                policyInformation.LimitsOfLiability.Occurance = "";
                policyInformation.LimitsOfLiability.Value = coveragename.LimitsOfLiability;
                policyInformation.LimitsOfLiability.PayableType = "";
                policyInformation.LimitsOfLiability.ValueType = "";

                policyInformation.Deductable.Section = coveragename.Coverage;
                policyInformation.Deductable.Code = homeOwners.FormIdentifier;
                policyInformation.Deductable.Name= coveragename.ApplicableDeductibles;
                policyInformation.Deductable.AdditionalInformation = "";
                policyInformation.Deductable.TotalAmount.Value = "";
                policyInformation.Deductable.TotalAmount.ValueType = "";
                    
            }


            //end of Coverage

            //Start of DatePeriod class 

            policyInformation.DatePeriod.From = homeOwners.PolicyPeriod.Period.From;
            policyInformation.DatePeriod.To= homeOwners.PolicyPeriod.Period.To;


            // End of DatePeriod

            // start of discount
            policyInformation.Discount.Section = "";
            policyInformation.Discount.Code = "";

            policyInformation.Discount.TotalAmount.ValueType = "Amount";
            foreach (var discountvalue in homeOwners.Discounts)
            {
                policyInformation.Discount.Name = discountvalue.Name;
                policyInformation.Discount.Value = discountvalue.Value;
                policyInformation.Discount.TotalAmount.Value = discountvalue.Value; ;

            }

            // End Of Discount Class

            // start of Endorsement class
            policyInformation.Endorsement.Section = "";
            policyInformation.Endorsement.Code = "";
            policyInformation.Endorsement.Name = "";
            policyInformation.Endorsement.ParentCoverage = "";
            policyInformation.Endorsement.FormNumber = "";
            policyInformation.Endorsement.Type = "";
            policyInformation.Endorsement.TotalAmount.Value = "";
            policyInformation.Endorsement.TotalAmount.ValueType = "";

            //End of endorsement

            // start of InsuranceCompanyInformation
            policyInformation.InsuranceCompanyInfo.Company = homeOwners.Agency_Data.Agency_Name;
            policyInformation.InsuranceCompanyInfo.ProviderEntityInformation = homeOwners.ProviderEntityName;
            policyInformation.InsuranceCompanyInfo.CustomerServiceContact = homeOwners.CustomerServiceNumber;
            policyInformation.InsuranceCompanyInfo.ClaimsReporting = "";
            //end of insuranceCompanyInfo

            //start of InsuranceAgency class
            policyInformation.InsurenceAgency.AgentName = homeOwners.Agency_Data.Agency_Name;
            policyInformation.InsurenceAgency.AgencyEmail = homeOwners.Agency_Data.Agency_Email;
            policyInformation.InsurenceAgency.AgencyContact = homeOwners.Agency_Data.Agency_Contact;
            policyInformation.InsurenceAgency.Address.AddressLine1 = homeOwners.Agency_Data.Agency_Address.AddressLine1;
            policyInformation.InsurenceAgency.Address.AddressLine2 = (string)homeOwners.Agency_Data.Agency_Address.AddressLine2;
            policyInformation.InsurenceAgency.Address.City = homeOwners.Agency_Data.Agency_Address.City;
            policyInformation.InsurenceAgency.Address.State = homeOwners.Agency_Data.Agency_Address.State;
            policyInformation.InsurenceAgency.Address.ZipCode= homeOwners.Agency_Data.Agency_Address.ZipCode;
            policyInformation.InsurenceAgency.Address.FullAddress= homeOwners.Agency_Data.Agency_Address.FullAddress;
             
             //End of Insurance Agency class



            // start of PolicyInformation


            
             
             
            

            


            // End Of PolicyInformation class

            // start of mortgage class
            policyInformation.Mortagaee.Name = "";
            policyInformation.Mortagaee.LoanNumber = "";
            policyInformation.Mortagaee.Value = "";
            policyInformation.Mortagaee.Mortagae = "";
             
            // end of mortgage class

            //start of InsuredProperty
            foreach (var insuredproperty in homeOwners.InsuredPropertyDetails) {
                policyInformation.InsuredPropertyDetails.Name = insuredproperty.Name;
                policyInformation.InsuredPropertyDetails.Value= insuredproperty.Value;
            }
             // end of insured property

        }
    }
}
