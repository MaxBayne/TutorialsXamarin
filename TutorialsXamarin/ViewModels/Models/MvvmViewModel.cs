using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorialsXamarin.Common.Models;
using TutorialsXamarin.Services;
using Xamarin.Forms;

namespace TutorialsXamarin.ViewModels
{
    public class MvvmViewModel:BaseViewModel, IMvvmViewModel
    {
        private readonly ICustomersService _customersService;

        public MvvmViewModel(ICustomersService customersService)
        {
            _customersService = customersService;

            //Initial Properties
            Customers = new ObservableCollection<Customer>(_customersService.GetCustomersToList());

            //Initial Commands
            ChangeNameCommand = new Command(OnChangeNameCommand);
            RemoveCustomerCommand = new Command(OnRemoveCustomerCommand);
            SelectionChangedCommand = new Command<Customer>(OnSelectionChangedCommand);
            SelectionChangedCommandParameter = new Command<Customer>(OnSelectionChangedCommandParameter);
        }

        #region Properites

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (_dateOfBirth != value)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged();
                }
            }
        }


        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer { get; set; }

        #endregion

        #region Commands

        public ICommand ChangeNameCommand { get; }
        private void OnChangeNameCommand()
        {
            FirstName = "Mohammed";
            LastName = "Salah";

            FullName = FirstName + " " + LastName;
             
        }

        public ICommand RemoveCustomerCommand { get; }
        private void OnRemoveCustomerCommand(object parameter)
        {
            Customers.Remove((Customer)parameter);
        }

        public ICommand SelectionChangedCommand { get; }
        private void OnSelectionChangedCommand(Customer parameter)
        {
            //SelectedCustomer = (Customer)parameter;
        }

        public ICommand SelectionChangedCommandParameter { get; }
        private void OnSelectionChangedCommandParameter(Customer parameter)
        {
            SelectedCustomer = parameter;
        }

        #endregion

        #region Helper



        #endregion
    }
}
