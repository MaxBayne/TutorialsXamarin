using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TutorialsXamarin.Business.Models;
using TutorialsXamarin.Data.Interfaces;
using TutorialsXamarin.Interfaces;
using TutorialsXamarin.Utilities;
using Xamarin.Forms;

// ReSharper disable once CheckNamespace
namespace TutorialsXamarin.ViewModels
{
    public class MvvmViewModel:BaseViewModel, IMvvmViewModel
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly ICustomersService _customersService;
        private readonly IMessagingCenter _messagingService;
        private readonly INavigationService _navigationService;

        public MvvmViewModel(ICustomersService customersService,INavigationService navigationService, IMessagingCenter messagingService)
        {
            _customersService = customersService;
            _navigationService = navigationService;
            _messagingService = messagingService;

            //Initial Properties
            Task.Run(async ()=>
            {
                await LoadDataAsync();
            });
            //var customersList = await _customersService.GetCustomersToListAsync();

            //Customers = new ObservableCollection<Customer>(customersList);

            //Initial Commands
            RefreshListCommand = new Command(OnRefreshListCommand);
            AddNewCustomerCommand = new Command(OnAddNewCustomerCommand);
            RemoveCustomerCommand = new Command(OnRemoveCustomerCommand);

            ChangeNameCommand = new Command(OnChangeNameCommand);
            
            SelectionChangedCommand = new Command(OnSelectionChangedCommand);

            ItemTabbedCommand = new Command<Customer>(OnItemTabbedCommand);
        }

        #region Parameters

        public override void InitializeParameter(object parameter)
        {
            if (parameter != null)
            {

            }
        }

        #endregion

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

        public ICommand AddNewCustomerCommand { get; set; }
        private async void OnAddNewCustomerCommand()
        {
            //_navigationService.NavigateToPage(ViewsNames.AddCustomer,"Iam Parameter");

            //_messagingService.Send(this, MessagesNames.Notification,"Register New Customer");

            await Shell.Current.GoToAsync(@"newcustomer");
        }
        
        public ICommand RefreshListCommand { get; set; }
        private void OnRefreshListCommand()
        {
            _navigationService.NavigateToModel(ViewsNames.ViewCustomer,"Hello World");

            _messagingService.Send(this, MessagesNames.Notification, "Refresh List of Customers");
        }

        public ICommand ChangeNameCommand { get; set; }
        private void OnChangeNameCommand()
        {
            FirstName = "Mohammed";
            LastName = "Salah";

            FullName = FirstName + " " + LastName;
             
        }

        public ICommand RemoveCustomerCommand { get; set; }
        private void OnRemoveCustomerCommand(object parameter)
        {
            Customers.Remove((Customer)parameter);
        }

        public ICommand SelectionChangedCommand { get; set; }
        private void OnSelectionChangedCommand()
        {
            Shell.Current.GoToAsync($"viewcustomer?id={SelectedCustomer.Code}");
        }
        

        public ICommand ItemTabbedCommand { get; set; }
        private void OnItemTabbedCommand(Customer customer)
        {
           
        }

        #endregion

        #region Helper

        private async Task LoadDataAsync()
        {
            var customersList = await _customersService.GetCustomersToListAsync();

            Customers = new ObservableCollection<Customer>(customersList);
        }

        #endregion
    }
}
