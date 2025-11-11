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
    }

    public class CustomerOutput
    {
        public string Name { get; set; }
        public string RiskProfile { get; set; }
        public double CreditScore { get; set; }
    }
}
