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

        #region Retrieve

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerDa.GetCustomerByIdAsync(customerId);

            if (customer != null)
            {
                return customer.Convert<Customer>();
            }

            return null;
        }

        public async Task<Customer> GetCustomerByCodeAsync(Guid customerCode)
        {
            var customer = await _customerDa.GetCustomerByCodeAsync(customerCode);

            if (customer != null)
            {
                return customer.Convert<Customer>();
            }

            return null;
        }

        public async Task<List<Customer>> GetCustomersToListAsync()
        {
            var customers = await _customerDa.GetCustomersToListAsync();
            if (customers != null)
            {
                return customers.Convert<List<Customer>>();
            }

            return null;
        }

        public async Task<ObservableCollection<Customer>> GetCustomersAsync()
        {
            var customers = await _customerDa.GetCustomersToCollectionAsync();

            if (customers != null)
            {
                return customers.Convert<ObservableCollection<Customer>>();
            }

            return null;
        }

        #endregion

        #region Insert

        public async Task<Customer> AddCustomer(Customer newCustomer)
        {
            //Convert Business Model To Access Model
            var model = newCustomer.Convert<DataAccess.Models.Customer>();

            var result = await _customerDa.AddCustomer(model);

            return result.Convert<Customer>();
        }

        #endregion

        #region Update

        public async Task<Customer> UpdateCustomer(Customer updatedCustomer)
        {
            //Convert Business Model To Access Model
            var model = updatedCustomer.Convert<DataAccess.Models.Customer>();

            var result = await _customerDa.UpdateCustomer(model);

            return result.Convert<Customer>();
        }

        #endregion

        #region Delete

        public async Task<bool> DeleteCustomer(Customer deletedCustomer)
        {
            //Convert Business Model To Access Model
            var model = deletedCustomer.Convert<DataAccess.Models.Customer>();

            return await _customerDa.DeleteCustomer(model);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customerDa.DeleteCustomer(id);
        }

        public async Task<bool> DeleteCustomer(Guid code)
        {
            return await _customerDa.DeleteCustomer(code);
        }

        #endregion
       
    }
}
