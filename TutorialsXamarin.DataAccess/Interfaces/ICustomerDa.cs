using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TutorialsXamarin.DataAccess.Models;

namespace TutorialsXamarin.DataAccess.Interfaces
{
    public interface ICustomerDa
    {
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> GetCustomerByCode(Guid customerCode);
        Task<List<Customer>> GetCustomersToList();
        Task<ObservableCollection<Customer>> GetCustomers();
    }
}