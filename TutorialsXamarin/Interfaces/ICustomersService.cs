using System.Collections.Generic;
using System.Collections.ObjectModel;
using TutorialsXamarin.Common.Models;

namespace TutorialsXamarin.Interfaces
{
    public interface ICustomersService
    {
        List<Customer> GetCustomersToList();
        ObservableCollection<Customer> GetCustomers();
    }
}