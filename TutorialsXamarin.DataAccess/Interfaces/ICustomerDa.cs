using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TutorialsXamarin.DataAccess.Models;

namespace TutorialsXamarin.DataAccess.Interfaces
{
    public interface ICustomerDa
    {
        /// <summary>
        /// Get Customer By Id [int]
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerByIdAsync(int customerId);

        /// <summary>
        /// Get Customer By Code [Guid]
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerByCodeAsync(Guid customerCode);

        /// <summary>
        /// Get Customers List
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> GetCustomersToListAsync();

        /// <summary>
        /// Get Customers Collection
        /// </summary>
        /// <returns></returns>
        Task<ObservableCollection<Customer>> GetCustomersToCollectionAsync();


        /// <summary>
        /// Add New Customer
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        Task<Customer> AddCustomer(Customer newCustomer);

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="updatedCustomer"></param>
        /// <returns></returns>
        Task<Customer> UpdateCustomer(Customer updatedCustomer);

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="deletedCustomer"></param>
        /// <returns></returns>
        Task<bool> DeleteCustomer(Customer deletedCustomer);

        /// <summary>
        /// Delete Customer By Id [int]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteCustomer(int id);

        /// <summary>
        /// Delete Customer By Code [Guid]
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<bool> DeleteCustomer(Guid code);
    }
}