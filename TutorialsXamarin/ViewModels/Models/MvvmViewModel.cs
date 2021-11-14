using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorialsXamarin.Common.Models;
using TutorialsXamarin.Services;
using Xamarin.Forms;

// ReSharper disable once CheckNamespace
namespace TutorialsXamarin.ViewModels
{
    public class MvvmViewModel:BaseViewModel, IMvvmViewModel
    {
        public MvvmViewModel(ICustomersService customersService)
        {
            //Initial Properties
            Customers = new ObservableCollection<Customer>(customersService.GetCustomersToList());

            //Initial Commands
            RefreshListCommand = new Command(OnRefreshListCommand);
            AddNewCustomerCommand = new Command(OnAddNewCustomerCommand);
            RemoveCustomerCommand = new Command(OnRemoveCustomerCommand);

            ChangeNameCommand = new Command(OnChangeNameCommand);
            
            SelectionChangedCommand = new Command<Customer>(OnSelectionChangedCommand);
            SelectionChangedCommandParameter = new Command<Customer>(OnSelectionChangedCommandParameter);

            ItemTabbedCommand = new Command<Customer>(OnItemTabbedCommand);
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

        public ICommand AddNewCustomerCommand { get; }
        private void OnAddNewCustomerCommand()
        {
         
        }
        
        public ICommand RefreshListCommand { get; }
        private void OnRefreshListCommand()
        {

        }

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

        public ICommand ItemTabbedCommand { get; }
        private void OnItemTabbedCommand(Customer customer)
        {

        }

        #endregion

        #region Helper



        #endregion
    }
}
