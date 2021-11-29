using System;
using System.Collections.Generic;
using System.Linq;
using TutorialsXamarin.DataAccess.Models;

namespace TutorialsXamarin.DataAccess.ContextsMock
{
    public static class MockDb
    {

        public static List<Customer> Customers = new List<Customer>
        {
            new Customer{Id=1,Code = Guid.Parse("a6013c45-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Mohammed",LastName = "Salah",DateOfBirth = DateTime.Now.AddYears(-20),Image = "Chrome.png"},
            new Customer{Id=2,Code = Guid.Parse("b5023b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Ahmed",LastName = "Ali",DateOfBirth = DateTime.Now.AddYears(-15),Image = "Chrome.png"},
            new Customer{Id=3,Code = Guid.Parse("a7523b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Ali",LastName = "Saied",DateOfBirth = DateTime.Now.AddYears(-10),Image = "Twitter.png"},
            new Customer{Id=4,Code = Guid.Parse("a7723b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Saied",LastName = "Salah",DateOfBirth = DateTime.Now.AddYears(-30),Image = "refresh24.png"},
            new Customer{Id=5,Code = Guid.Parse("a7823b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Mona",LastName = "Saied",DateOfBirth = DateTime.Now.AddYears(-44),Image = "iTunes.png"},
            new Customer{Id=6,Code = Guid.Parse("a7923b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Maged",LastName = "Salah",DateOfBirth = DateTime.Now.AddYears(-15),Image = "Chrome.png"},
            new Customer{Id=7,Code = Guid.Parse("a8123b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Hoda",LastName = "Ali",DateOfBirth = DateTime.Now.AddYears(-70),Image = "Chrome.png"},
            new Customer{Id=8,Code = Guid.Parse("a8223b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Om Mohammed",LastName = "Ahmed",DateOfBirth = DateTime.Now.AddYears(-23),Image = "Twitter.png"},
            new Customer{Id=9,Code = Guid.Parse("a8323b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Mdeo",LastName = "Saied",DateOfBirth = DateTime.Now.AddYears(-40),Image = "Chrome.png"},
            new Customer{Id=10,Code = Guid.Parse("a8423b25-9d46-4ef1-abaa-a1fcaaecdca2"),FirstName = "Ally",LastName = "Ahmed",DateOfBirth = DateTime.Now.AddYears(-33),Image = "iTunes.png"}

        };

        #region Customers

        public static Customer AddCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
            return newCustomer;
        }
        public static Customer UpdateCustomer(Customer updatedCustomer)
        {
            try
            {
                var currentCustomer = Customers.FirstOrDefault(c => c.Code == updatedCustomer.Code);

                if (currentCustomer != null)
                {
                    currentCustomer.FirstName = updatedCustomer.FirstName;
                    currentCustomer.LastName = updatedCustomer.LastName;
                    currentCustomer.DateOfBirth = updatedCustomer.DateOfBirth;
                    currentCustomer.Image= updatedCustomer.Image;

                    return currentCustomer;
                }
                else
                {
                    return null;
                }

                
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public static bool RemoveCustomer(Customer removedCustomer)
        {
            try
            {

                var currentCustomer = Customers.FirstOrDefault(c => c.Code == removedCustomer.Code);

                if (currentCustomer != null)
                {
                    Customers.Remove(currentCustomer);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Customer FindCustomerByCode(Guid code)
        {
            return Customers.FirstOrDefault(c => c.Code == code);
        }
        public static Customer FindCustomerById(int id)
        {
            return Customers.FirstOrDefault(c => c.Id == id);
        }

        #endregion
    }
}
