using System;
using System.Collections.Generic;
using System.Linq;
using TutorialsXamarin.DataAccess.Models;

namespace TutorialsXamarin.DataAccess.ContextsMock
{
    public class MockDb
    {
        public MockDb()
        {
            if (Customers == null)
            {
                Customers = new List<Customer>
                {
                    new Customer{Code = Guid.Parse("a6013c45-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Mohammed",LastName = "Salah",DateOfBirth = DateTime.Now.AddYears(-20),Image = "Chrome.png"},
                    new Customer{Code = Guid.Parse("b5023b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Ahmed",LastName = "Ali",DateOfBirth = DateTime.Now.AddYears(-15),Image = "Chrome.png"},
                    new Customer{Code = Guid.Parse("a7523b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Ali",LastName = "Saied",DateOfBirth = DateTime.Now.AddYears(-10),Image = "Twitter.png"},
                    new Customer{Code = Guid.Parse("a7723b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Saied",LastName = "Salah",DateOfBirth = DateTime.Now.AddYears(-30),Image = "refresh24.png"},
                    new Customer{Code = Guid.Parse("a7823b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Mona",LastName = "Saied",DateOfBirth = DateTime.Now.AddYears(-44),Image = "iTunes.png"},
                    new Customer{Code = Guid.Parse("a7923b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Maged",LastName = "Salah",DateOfBirth = DateTime.Now.AddYears(-15),Image = "Chrome.png"},
                    new Customer{Code = Guid.Parse("a8123b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Hoda",LastName = "Ali",DateOfBirth = DateTime.Now.AddYears(-70),Image = "Chrome.png"},
                    new Customer{Code = Guid.Parse("a8223b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Om Mohammed",LastName = "Ahmed",DateOfBirth = DateTime.Now.AddYears(-23),Image = "Twitter.png"},
                    new Customer{Code = Guid.Parse("a8323b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Mdeo",LastName = "Saied",DateOfBirth = DateTime.Now.AddYears(-40),Image = "Chrome.png"},
                    new Customer{Code = Guid.Parse("a8423b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Ally",LastName = "Ahmed",DateOfBirth = DateTime.Now.AddYears(-33),Image = "iTunes.png"}
                };
            }
        }

        public List<Customer> Customers { get; set; }
        public void AddCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
        }
        public void UpdateCustomer(Customer updatedCustomer)
        {
            var currentCustomer = Customers.FirstOrDefault(c => c.Code == updatedCustomer.Code);

            if (currentCustomer != null)
            {
                currentCustomer.FirstName = updatedCustomer.FirstName;
                currentCustomer.LastName = updatedCustomer.LastName;
                currentCustomer.DateOfBirth = updatedCustomer.DateOfBirth;
            }
        }
        public void RemoveCustomer(Customer removedCustomer)
        {
            var currentCustomer = Customers.FirstOrDefault(c => c.Code == removedCustomer.Code);

            if (currentCustomer != null)
            {
                Customers.Remove(currentCustomer);
            }
        }

        public Customer FindCustomerByCode(Guid code)
        {
            return Customers.FirstOrDefault(c => c.Code == code);
        }

        public Customer FindCustomerById(int id)
        {
            return Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
