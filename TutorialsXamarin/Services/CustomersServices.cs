﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using TutorialsXamarin.Common.Models;
using TutorialsXamarin.DataAccess;

namespace TutorialsXamarin.Services
{
    public interface ICustomersService
    {
        List<Customer> GetCustomersToList();
        ObservableCollection<Customer> GetCustomers();
    }

    public class CustomersService : ICustomersService
    {
        public List<Customer> GetCustomersToList()
        {
            return CustomersDataAccess.Customers;
        }

        public ObservableCollection<Customer> GetCustomers()
        {
            var observableCollection = new ObservableCollection<Customer>();

            CustomersDataAccess.Customers.ForEach(customer=>observableCollection.Add(customer));

            return observableCollection;
        }
    }

    
}