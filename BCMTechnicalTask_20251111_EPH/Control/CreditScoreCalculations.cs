using BCMTechnicalTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCMTechnicalTask.Control
{
    internal class CreditScoreCalculations
    {
        public static List<CustomerOutput> CalculateCreditScore(List<CustomerInput> Customers)
        {
            List<CustomerOutput> _repsonse = new List<CustomerOutput>();
            foreach (var Customer in Customers)
            {
                CustomerOutput _output = new CustomerOutput();
                _output.Name = Customer.Name;
                _output.CreditScore = (0.4 * Customer.PaymentHistory) + (0.3 * (100 - Customer.CreditUtilization)) + (0.3 * Math.Min(Customer.AgeOfCreditHistory, 10));
                _output.RiskProfile = (_output.CreditScore >= 50) ? "LOW" : "HIGH";
                _repsonse.Add(_output);
            }
            return _repsonse;
        }
    }
}
