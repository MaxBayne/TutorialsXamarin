using System.ComponentModel;
using System.Windows.Input;
using TutorialsXamarin.Business.Models;
using TutorialsXamarin.Data.Interfaces;
using Xamarin.Forms;

// ReSharper disable once CheckNamespace
namespace TutorialsXamarin.ViewModels
{
    public class ViewCustomerViewModel : BaseViewModel, IViewCustomerViewModel
    {
        private readonly ICustomersService _customersService;

        public ViewCustomerViewModel(ICustomersService customersService)
        {
            _customersService = customersService;

            //Initialize Properties
            //Customer = new Customer();

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

        private Customer _customer;
        public Customer Customer
        {
            get=> _customer;
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        #endregion

    }
}