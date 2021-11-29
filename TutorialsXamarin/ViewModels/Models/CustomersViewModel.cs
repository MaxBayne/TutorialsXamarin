using Xamarin.Forms;
using System.Windows.Input;
using TutorialsXamarin.Business.Models;
using TutorialsXamarin.Data.Interfaces;


// ReSharper disable once CheckNamespace
namespace TutorialsXamarin.ViewModels
{
    public class CustomersViewModel: BaseViewModel
    {
        private readonly ICustomersService _customersService;

        public CustomersViewModel(ICustomersService customersService)
        {
            _customersService = customersService;

            //Initialize Properties
            Customer = new Customer();

            //Initialize Commands
            GetCustomerCommand = new Command<string>(OnGetCustomerCommand);
            GoToCustomersListCommand = new Command(OnGoToCustomersListCommand);
        }

        #region Commands

        public ICommand GetCustomerCommand { get; }
        private async void OnGetCustomerCommand(string code)
        {
            Customer = await _customersService.GetCustomerByCodeAsync(System.Guid.Parse(code));
        }

        public ICommand GoToCustomersListCommand { get; }
        private async void OnGoToCustomersListCommand()
        {
            await Shell.Current.GoToAsync("customers");
        }


        #endregion

        #region 

        public Customer Customer { get; set; }

        #endregion

    }
}
