using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TutorialsXamarin.DataAccess.Interfaces;
using TutorialsXamarin.Business.Models;
using TutorialsXamarin.Business.Interfaces;
using TutorialsXamarin.Common.Enums;
using TutorialsXamarin.Common.Extensions;
using TutorialsXamarin.DataAccess.Da;

namespace TutorialsXamarin.Business.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerDa _customerDa;

        public CustomerManager(ConnectionType connectionType)
        {
            _customerDa = new CustomerDa(connectionType);
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customer = await _customerDa.GetCustomerById(customerId);

            if (customer != null)
            {
                return customer.Convert<Customer>();
            }

            return null;
        }

        public async Task<Customer> GetCustomerByCode(Guid customerCode)
        {
            var customer = await _customerDa.GetCustomerByCode(customerCode);

            if (customer != null)
            {
                return customer.Convert<Customer>();
            }

            return null;
        }

        public async Task<List<Customer>> GetCustomersToList()
        {
            var customers = await _customerDa.GetCustomersToList();
            if (customers != null)
            {
                return customers.Convert<List<Customer>>();
            }

            return null;
        }

        public async Task<ObservableCollection<Customer>> GetCustomers()
        {
            var customers = await _customerDa.GetCustomers();

            if (customers != null)
            {
                return customers.Convert<ObservableCollection<Customer>>();
            }

            return null;
        }
    }
}
