using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TutorialsXamarin.Common.Enums;
using TutorialsXamarin.DataAccess.Abstracts;
using TutorialsXamarin.DataAccess.Interfaces;
using TutorialsXamarin.DataAccess.Models;
using TutorialsXamarin.DataAccess.ContextsMock;

namespace TutorialsXamarin.DataAccess.Da
{

    public class CustomerDa : DataAccessBase, ICustomerDa
    {
        public CustomerDa(ConnectionType connectionType) : base(connectionType) {}

        #region Retrieve

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data
                return await Db.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            }
            else
            {
                //Mock Data
                return MockDb.FindCustomerById(customerId);
            }
        }

        public async Task<Customer> GetCustomerByCodeAsync(Guid customerCode)
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data
                return await Db.Customers.FirstOrDefaultAsync(c => c.Code == customerCode);
            }
            else
            {
                //Mock Data
                return MockDb.FindCustomerByCode(customerCode);
            }
        }

        public async Task<List<Customer>> GetCustomersToListAsync()
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data
                return await Db.Customers.ToListAsync();
            }
            else if(ConnectionType == ConnectionType.Mock)
            {
                //Mock Data
                return MockDb.Customers;
            }
            

            return null;
        }

        public async Task<ObservableCollection<Customer>> GetCustomersToCollectionAsync()
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data
                return new ObservableCollection<Customer>(await Db.Customers.ToListAsync());
            }
            else
            {
                //Mock Data
                return new ObservableCollection<Customer>(MockDb.Customers);
            }
        }

        #endregion

        #region Insert

        public async Task<Customer> AddCustomer(Customer newCustomer)
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data

                newCustomer.Id = await Db.Customers.MaxAsync(c => c.Id)+1;
                newCustomer.Code = Guid.NewGuid();

                var createdCustomer = Db.Customers.Add(newCustomer);

                await Db.SaveChangesAsync();

                return createdCustomer.Entity;
            }
            else
            {
                //Mock Data

                newCustomer.Id = MockDb.Customers[^1].Id + 1;
                newCustomer.Code = Guid.NewGuid();

                return MockDb.AddCustomer(newCustomer);
            }
        }


        #endregion

        #region Update

        public async Task<Customer> UpdateCustomer(Customer updatedCustomer)
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data

                var oldCustomer = await Db.Customers.FirstOrDefaultAsync(c => c.Code == updatedCustomer.Code);

                if (oldCustomer == null)
                {
                    return null;
                }

                Db.Entry(oldCustomer).CurrentValues.SetValues(updatedCustomer);
                await Db.SaveChangesAsync();

                return updatedCustomer;
            }
            else
            {
                //Mock Data
                return MockDb.UpdateCustomer(updatedCustomer);
            }
        }

        #endregion

        #region Delete
        public async Task<bool> DeleteCustomer(Customer deletedCustomer)
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data

                var currentCustomer = await Db.Customers.FirstOrDefaultAsync(c => c.Code == deletedCustomer.Code);

                if (currentCustomer == null)
                {
                    return false;
                }

                Db.Customers.Remove(currentCustomer);
                
                await Db.SaveChangesAsync();

                return true;
            }
            else
            {
                //Mock Data
                return MockDb.RemoveCustomer(deletedCustomer);
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data

                var currentCustomer = await Db.Customers.FirstOrDefaultAsync(c => c.Id == id);

                if (currentCustomer == null)
                {
                    return false;
                }

                Db.Customers.Remove(currentCustomer);

                await Db.SaveChangesAsync();

                return true;
            }
            else
            {
                var currentCustomer = MockDb.FindCustomerById(id);

                //Mock Data
                return MockDb.RemoveCustomer(currentCustomer);
            }
        }

        public async Task<bool> DeleteCustomer(Guid code)
        {
            if (ConnectionType == ConnectionType.Sqlserver)
            {
                //SQL Data

                var currentCustomer = await Db.Customers.FirstOrDefaultAsync(c => c.Code == code);

                if (currentCustomer == null)
                {
                    return false;
                }

                Db.Customers.Remove(currentCustomer);

                await Db.SaveChangesAsync();

                return true;
            }
            else
            {
                var currentCustomer = MockDb.FindCustomerByCode(code);

                //Mock Data
                return MockDb.RemoveCustomer(currentCustomer);
            }
        }


        #endregion







    }
}
