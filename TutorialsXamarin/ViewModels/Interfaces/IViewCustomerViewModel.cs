using System.ComponentModel;
using System.Windows.Input;
using TutorialsXamarin.Business.Models;

namespace TutorialsXamarin.ViewModels
{
    public interface IViewCustomerViewModel
    {
        ICommand GetCustomerCommand { get; }
        ICommand GoToCustomersListCommand { get; }
        Customer Customer { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        void InitializeParameter(object parameter);
    }
}