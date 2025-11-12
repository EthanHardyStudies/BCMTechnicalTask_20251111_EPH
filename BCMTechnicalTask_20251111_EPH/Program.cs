using System;
using BCMTechnicalTask.Models;
using BCMTechnicalTask.Control;
using System.Data;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

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
                _customerList = null;// In case the data must be entered again due to parsing or validation errors, nullify the list.
                Console.Write("\nEnter customer data:\n");
                bool _validData = true;
                
                StringBuilder _inputData = new StringBuilder(); //String builder to allow for appending multiple lines together.
                string line;
                while (!string.IsNullOrWhiteSpace(line = Console.ReadLine())) //loop through the lines of the console until an empty line is entered. This allows multi line entries.
                {
                    _inputData.Append(line);
                }

                //Try parse the entered data. provide an error if the parsing fails.
                try
                {
                    _customerList = JsonConvert.DeserializeObject<List<CustomerInput>>(_inputData.ToString());
                    
                    foreach (CustomerInput _customer in _customerList)
                    {
                        string _validation = _customer.Validate();
                        if (_validation.Length > 0)
                        {
                            _validData = false;
                            Console.WriteLine("Invalid data entered. CustomerID: " + _customer.CustomerId.ToString() + " Errors: \n" + _validation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to parse input. Error: " + ex.Message);
                    _validData = false;
                }                

                if (_validData)
                {
                    _addingCustomers = false;
                }
            }

            Console.WriteLine("\n|=============== Credit Score Report ===============| \n");

            //Call the method to calculate the credit scores for customers.
            List<CustomerOutput> _results = CreditScoreCalculations.CalculateCreditScore(_customerList);

            JArray _printResults = JsonConvert.DeserializeObject<JArray>(JsonConvert.SerializeObject(_results.ToArray())); //convert list to json array for printing to file
            Console.WriteLine(JsonConvert.SerializeObject(_printResults, Formatting.Indented)); //Write results to the console in json array format
            
            File.WriteAllText("CreditResults.json", _printResults.ToString(Formatting.Indented)); //Print result array to json file.
            Console.WriteLine("\n|=============== Thank you for using this service. ===============| \n");
        }
    }
}