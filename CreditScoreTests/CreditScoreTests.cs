using BCMTechnicalTask.Control;
using BCMTechnicalTask.Models;

namespace CreditScoreTests
{
    public class CreditScoreTests
    {
        private CreditScoreCalculations calculations { get; set; } = null;
        private List<CustomerInput> customersTest;
        private List<CustomerOutput> customersResult;
        [SetUp]
        public void Setup()
        {
            calculations = new CreditScoreCalculations();
            customersTest = new List<CustomerInput>()
            {
                new CustomerInput()
                {
                    CustomerId = 1,
                    Name = "Alice",
                    PaymentHistory = 90,
                    CreditUtilization = 40,
                    AgeOfCreditHistory = 5,

                },
                new CustomerInput()
                {
                    CustomerId = 2,
                    Name = "Bob",
                    PaymentHistory = 70,
                    CreditUtilization = 90,
                    AgeOfCreditHistory = 15,

                },
                new CustomerInput()
                {
                    CustomerId = 3,
                    Name = "Charlie",
                    PaymentHistory = 60,
                    CreditUtilization = 30,
                    AgeOfCreditHistory = 2,

                }
            };
            customersResult = new List<CustomerOutput>()
            {
                new CustomerOutput()
                {
                    Name = "Alice",
                    CreditScore = 55.5,
                    RiskProfile = "LOW"
                },
                new CustomerOutput()
                {
                    Name = "Bob",
                    CreditScore = 34,
                    RiskProfile = "HIGH"
                },
                new CustomerOutput()
                {
                    Name = "Charlie",
                    CreditScore = 45.6,
                    RiskProfile = "HIGH"
                }
            };
        }


        [Test]
        public void GetCreditScores()
        {
            List<CustomerOutput> _testResults = CreditScoreCalculations.CalculateCreditScore(customersTest);
            for (int i = 0;i< _testResults.Count;i++)
            {
                Assert.AreEqual(_testResults[i].Name, customersResult[i].Name);
                Assert.AreEqual(_testResults[i].CreditScore, customersResult[i].CreditScore);
                Assert.AreEqual(_testResults[i].RiskProfile, customersResult[i].RiskProfile);
            }
        }
    }
}