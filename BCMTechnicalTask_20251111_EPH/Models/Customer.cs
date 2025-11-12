using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCMTechnicalTask.Models
{
    public class CustomerInput
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int PaymentHistory { get; set; }
        public int CreditUtilization { get; set; }
        public int AgeOfCreditHistory { get; set; }
        public double CreditScore { get; set; }

        public string Validate()
        {
            string _response = "";
            if (CustomerId <= 0)
            {
                _response += "CustomerID error: Invalid value provided, customer IDs cannot be less than 1.";
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                if (_response.Length > 0) { _response += "\n"; }
                _response += "Name error: Name cannot be null or blank.";
            }
            if (PaymentHistory < 0 || PaymentHistory > 100)
            {
                if (_response.Length > 0) { _response += "\n"; }
                _response += "PaymentHistory error: Payment History must be a whole number between 0 and 100.";
            }
            if (CreditUtilization < 0 || CreditUtilization > 100)
            {
                if (_response.Length > 0) { _response += "\n"; }
                _response += "CreditUtilization error: Credit Utilization must be a whole number between 0 and 100.";
            }
            if (AgeOfCreditHistory < 0)
            {
                if (_response.Length > 0) { _response += "\n"; }
                _response += "Age Of Credit History error: Age of Credit history must be greater than or equal to 0.";
            }
            return _response;
        }
    }

    public class CustomerOutput
    {
        public string Name { get; set; }
        public string RiskProfile { get; set; }
        public double CreditScore { get; set; }
    }
}
