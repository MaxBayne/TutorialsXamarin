using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TutorialsXamarin.Business.Models;

namespace TutorialsXamarin.Business.Interfaces
{
    public interface ICustomerManager
    {
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> GetCustomerByCode(Guid customerCode);
        Task<List<Customer>> GetCustomersToList();
        Task<ObservableCollection<Customer>> GetCustomers();
    }
}