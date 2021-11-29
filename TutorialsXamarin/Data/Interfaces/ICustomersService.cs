using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TutorialsXamarin.Business.Models;

namespace TutorialsXamarin.Data.Interfaces
{
    public interface ICustomersService
    {

        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> GetCustomerByCodeAsync(Guid customerCode);
        Task<List<Customer>> GetCustomersToListAsync();
        Task<ObservableCollection<Customer>> GetCustomersAsync();

        Task<Customer> AddCustomer(Customer newCustomer);
        
        Task<Customer> UpdateCustomer(Customer updatedCustomer);
        
        Task<bool> DeleteCustomer(int id);
        Task<bool> DeleteCustomer(Guid code);
    }
}