using BCMTechnicalTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BCMTechnicalTask.Control
{
    public class CreditScoreCalculations
    {
        public static List<CustomerOutput> CalculateCreditScore(List<CustomerInput> Customers)
        {
            List<CustomerOutput> _repsonse = new List<CustomerOutput>(); //create response object
            foreach (var Customer in Customers) //loop through input list to calculate scores and create response items.
            {
                CustomerOutput _output = new CustomerOutput(); //create object for response list
                _output.Name = Customer.Name; //assign name to response
                _output.CreditScore = Math.Round((0.4 * Customer.PaymentHistory) + (0.3 * (100 - Customer.CreditUtilization)) + (0.3 * Math.Min(Customer.AgeOfCreditHistory, 10)),2);//calculate credit score
                _output.RiskProfile = (_output.CreditScore >= 50) ? "LOW" : "HIGH"; //determine if customer is high or low risk based on credit score
                _repsonse.Add(_output);//add object to response
            }
            return _repsonse;
        }
    }
}
