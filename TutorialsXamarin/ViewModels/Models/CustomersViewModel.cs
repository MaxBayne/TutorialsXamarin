using Xamarin.Forms;
using System.Windows.Input;


namespace TutorialsXamarin.ViewModels
{
    public class CustomersViewModel: BaseViewModel
    {
        //private readonly CustomerManager _customerService;

        public CustomersViewModel()
        {
            //_customerService = new CustomerManager();
            GetCustomerCommand = new Command(() =>
            {
                //var customer = _customerService.GetCustomerById(100);
                
            });
        }

        #region Commands

        public ICommand GetCustomerCommand { get; }

        #endregion

    }
}
