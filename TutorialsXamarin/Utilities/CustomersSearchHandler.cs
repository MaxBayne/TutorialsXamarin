using Xamarin.Forms;
using System.Linq;
using TutorialsXamarin.Business.Interfaces;
using TutorialsXamarin.Business.Models;
using TutorialsXamarin.Business.Managers;

namespace TutorialsXamarin.Utilities
{
    public class CustomersSearchHandler:SearchHandler
    {
        private readonly ICustomerManager _customersManager;
        public CustomersSearchHandler()
        {
            _customersManager = new CustomerManager(App.ConnectionType);
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                var customersList = _customersManager.GetCustomersToList();
                ItemsSource = customersList.Result.Where(c => c.FullName.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            if (item != null)
            {
                var customer = (Customer) item;

                Shell.Current.GoToAsync($"viewcustomer?id={customer.Code}");
            }

        }
    }
}
