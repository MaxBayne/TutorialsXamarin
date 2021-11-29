using Xamarin.Forms;
using System.Windows.Input;
using TutorialsXamarin.Business.Interfaces;
using TutorialsXamarin.Business.Models;


// ReSharper disable once CheckNamespace
namespace TutorialsXamarin.ViewModels
{
    public class CustomersViewModel: BaseViewModel
    {
        private readonly ICustomerManager _customersManager;

        public CustomersViewModel(ICustomerManager customersManager)
        {
            _customersManager = customersManager;

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
            Customer = await _customersManager.GetCustomerByCode(System.Guid.Parse(code));
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
