using Xamarin.Forms;
using System.Linq;
using TutorialsXamarin.Business.Models;
using TutorialsXamarin.Data.Interfaces;

namespace TutorialsXamarin.Utilities
{
    public class CustomersSearchHandler:SearchHandler
    {
        private readonly ICustomersService _customersService;

        public CustomersSearchHandler()
        {
         
        }
        public CustomersSearchHandler(ICustomersService customersService)
        {
            //_customersService = new CustomersService(App.CacheService);
            _customersService = customersService;
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
                var customersList = _customersService.GetCustomersToListAsync();
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
