using System;
using System.Collections.Generic;
using System.Linq;
using TutorialsXamarin.Common.Models;

namespace TutorialsXamarin.DataAccess
{
    public static class CustomersDataAccess
    {
        static CustomersDataAccess()
        {
            if (Customers == null)
            {
                Customers = new List<Customer>()
                {
                    new Customer{Code = new Guid(),FirstName = "Mohammed",LastName = "Salah",DateOfBirth = DateTime.Now.AddYears(-20),Image = "Chrome.png"},
                    new Customer{Code = new Guid(),FirstName = "Ahmed",LastName = "Ali",DateOfBirth = DateTime.Now.AddYears(-15),Image = "Chrome.png"},
                    new Customer{Code = new Guid(),FirstName = "Ali",LastName = "Saied",DateOfBirth = DateTime.Now.AddYears(-10),Image = "Twitter.png"},
                    new Customer{Code = new Guid(),FirstName = "Saied",LastName = "Salah",DateOfBirth = DateTime.Now.AddYears(-30),Image = "refresh24.png"},
                    new Customer{Code = new Guid(),FirstName = "Mona",LastName = "Saied",DateOfBirth = DateTime.Now.AddYears(-44),Image = "iTunes.png"},
                    new Customer{Code = new Guid(),FirstName = "Maged",LastName = "Salah",DateOfBirth = DateTime.Now.AddYears(-15),Image = "Chrome.png"},
                    new Customer{Code = new Guid(),FirstName = "Hoda",LastName = "Ali",DateOfBirth = DateTime.Now.AddYears(-70),Image = "Chrome.png"},
                    new Customer{Code = new Guid(),FirstName = "Om Mohammed",LastName = "Ahmed",DateOfBirth = DateTime.Now.AddYears(-23),Image = "Twitter.png"},
                    new Customer{Code = new Guid(),FirstName = "Mdeo",LastName = "Saied",DateOfBirth = DateTime.Now.AddYears(-40),Image = "Chrome.png"},
                    new Customer{Code = new Guid(),FirstName = "Ally",LastName = "Ahmed",DateOfBirth = DateTime.Now.AddYears(-33),Image = "iTunes.png"}

                };
            }
        }

        public static List<Customer> Customers { get; set; }
        public static void AddCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
        }
        public static void UpdateCustomer(Customer updatedCustomer)
        {
            var currentCustomer = Customers.FirstOrDefault(c => c.Code == updatedCustomer.Code);

            if (currentCustomer != null)
            {
                currentCustomer.FirstName = updatedCustomer.FirstName;
                currentCustomer.LastName = updatedCustomer.LastName;
                currentCustomer.DateOfBirth = updatedCustomer.DateOfBirth;
            }
        }
        public static void RemoveCustomer(Customer removedCustomer)
        {
            var currentCustomer = Customers.FirstOrDefault(c => c.Code == removedCustomer.Code);

            if (currentCustomer != null)
            {
                Customers.Remove(currentCustomer);
            }
        }

        public static Customer FindCustomerByCode(Guid code)
        {
            return Customers.FirstOrDefault(c => c.Code == code);
        }


    }
}
