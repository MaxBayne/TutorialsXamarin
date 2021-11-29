using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorialsXamarin.Common.Enums;
using TutorialsXamarin.DataAccess.Abstracts;
using TutorialsXamarin.DataAccess.Interfaces;
using TutorialsXamarin.DataAccess.Models;

namespace TutorialsXamarin.DataAccess.Da
{

    public class CustomerDa : DataAccessBase, ICustomerDa
    {
        public CustomerDa(ConnectionType connectionType) : base(connectionType) {}
   

        public async Task<Customer> GetCustomerById(int customerId)
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data
                return await Db.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            }
            else
            {
                //Mock Data
                return Mock.FindCustomerById(customerId);
            }
        }

        public async Task<Customer> GetCustomerByCode(Guid customerCode)
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data
                return await Db.Customers.FirstOrDefaultAsync(c => c.Code == customerCode);
            }
            else
            {
                //Mock Data
                return Mock.FindCustomerByCode(customerCode);
            }
        }

        public async Task<List<Customer>> GetCustomersToList()
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data
                return await Db.Customers.ToListAsync();
            }
            else
            {
                //Mock Data
                return Mock.Customers;
            }
        }

        public async Task<ObservableCollection<Customer>> GetCustomers()
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data
                return new ObservableCollection<Customer>(await Db.Customers.ToListAsync());
            }
            else
            {
                //Mock Data
                return new ObservableCollection<Customer>(Mock.Customers);
            }
        }
    }
}
