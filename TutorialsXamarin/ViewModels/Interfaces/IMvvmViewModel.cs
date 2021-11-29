using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorialsXamarin.Business.Models;

namespace TutorialsXamarin.ViewModels
{
    public interface IMvvmViewModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }
        DateTime DateOfBirth { get; set; }

        ObservableCollection<Customer> Customers { get; set; }

        ICommand ChangeNameCommand { get; }
    }
}