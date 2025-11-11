using System;
using BCMTechnicalTask.Models;
using BCMTechnicalTask.Control;
using System.Data;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BCMTechnicalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CustomerInput> _customerList = new List<CustomerInput>();
            bool _addingCustomers = true;
            Console.WriteLine("|=============== BCM Customer Credit Score Calculator ===============| \n");
            while(_addingCustomers)
            {
                CustomerInput _customer = new CustomerInput();

                //Ask user to enter the customer ID
                int _idTemp; //Create local variable to try parse the integer input for the id
                bool _validID = false; //declare boolean to allow for looping if the input is not an integer.
                while (!_validID)
                {
                    Console.Write("\nEnter customer ID:\n");
                    bool _idParse = int.TryParse(Console.ReadLine(), out _idTemp); //Try parse the input value
                    if (_idParse && _idTemp >= 1) //Check if value was parsed correctly and is positive
                    {
                        _customer.CustomerId = _idTemp; //update customer attribute using temp variable.
                        _validID = true; //update the loop condition to exit the loop.
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid customer ID of type integer."); //if the value was not parsed successfully display and error for the user.
                    }
                }


                //Ask user to enter the customers name
                Console.Write("\nEnter the customers name:\n");
                _customer.Name = Console.ReadLine();

                //Ask user to enter the payment history score
                int _payHistTemp; //Create local variable to try parse the integer input
                bool _validPayHist = false; //declare boolean to allow for looping if the input is not an integer.
                while (!_validPayHist)
                {
                    Console.Write("\nEnter customers payment history score (0 - 100):\n");
                    bool _payHistParse = int.TryParse(Console.ReadLine(), out _payHistTemp); //Try parse the input value
                    if (_payHistParse && (_payHistTemp >= 0 && _payHistTemp <= 100))//Check if value was parsed correctly and is between 0 and 100
                    {
                        _customer.PaymentHistory = _payHistTemp;//update customer attribute using temp variable.
                        _validPayHist = true;//update the loop condition to exit the loop.
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid payment history score of type integer.");//if the value was not parsed successfully display and error for the user.
                    }
                }

                //Ask user to enter the credit utilization score
                int _creditUtTemp; //Create local variable to try parse the integer input
                bool _validcreditUt = false; //declare boolean to allow for looping if the input is not an integer.
                while (!_validcreditUt)
                {
                    Console.Write("\nEnter the customers credit utilization score (0 - 100):\n");
                    bool _creditUtParse = int.TryParse(Console.ReadLine(), out _creditUtTemp); //Try parse the input value
                    if (_creditUtParse && (_creditUtTemp >= 0 && _creditUtTemp <= 100))//Check if value was parsed correctly and is between 0 and 100
                    {
                        _customer.CreditUtilization = _creditUtTemp;//update customer attribute using temp variable.
                        _validcreditUt = true;//update the loop condition to exit the loop.
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid credit utilization score of type integer.");//if the value was not parsed successfully display and error for the user.
                    }
                }

                //Ask user to enter the age of the customers credit history
                int _creditAgeTemp;//Create local variable to try parse the integer input
                bool _validCreditAge = false; //declare boolean to allow for looping if the input is not an integer.
                while (!_validCreditAge)
                {
                    Console.Write("\nEnter the age of the customers credit history (in years):\n");
                    bool _creditAgeParse = int.TryParse(Console.ReadLine(), out _creditAgeTemp); //Try parse the input value
                    if (_creditAgeParse && _creditAgeTemp >= 0) //Check if value was parsed correctly and is positive
                    {
                        _customer.AgeOfCreditHistory = _creditAgeTemp;//update customer attribute using temp variable.
                        _validCreditAge = true;//update the loop condition to exit the loop.
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid credit history age of type integer.");//if the value was not parsed successfully display and error for the user.
                    }
                }

                //Add customer into object list that will be processed.
                _customerList.Add(_customer); 

                //Ask user to decide if they want to continue adding customers
                Console.Write("\nWould you like to input another customers details for your report? (Y/N)\n");
                string _continue = Console.ReadLine();
                if (_continue.ToLower() == "n") 
                {
                    _addingCustomers = false;//Break the while loop if the customer does not want to add another customer.
                }
            }

            Console.WriteLine("\n|=============== Credit Score Report ===============| \n");

            //Call the method to calculate the credit scores for customers.
            List<CustomerOutput> _results = CreditScoreCalculations.CalculateCreditScore(_customerList);

            //loop through and print results to console
            for (int i = 0; i < _results.Count; i++)
            {
                Console.WriteLine("|=== Customer Number " + (i + 1).ToString() + " ===|\n\n"
                    + "Customer Name: " + _results[i].Name + "\n"
                    + "Credit Score: " + _results[i].CreditScore.ToString() + "\n"
                    + "Risk profile: " + _results[i].RiskProfile + "\n");
            }

            JArray _printResults = JsonConvert.DeserializeObject<JArray>(JsonConvert.SerializeObject(_results.ToArray())); //convert list to json array for printing to file
            File.WriteAllText("CreditResults.json", _printResults.ToString(Formatting.Indented)); //Print result array to json file.
            Console.WriteLine("\n|=============== Thank you for using this service. ===============| \n");
        }
    }
}