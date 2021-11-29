using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [QueryProperty(nameof(CustomerCode),"id")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCustomer
    {
        private CustomersViewModel _viewModel;

        public ViewCustomer()
        {
            InitializeComponent();

            //App.MessagingService.Subscribe<MvvmViewModel, string>(this, MessagesNames.Notification, (sender, args) =>
            //{
            //    LblContent.Text = args;
            //});


            //BindingContext = viewModel = ViewModelLocator.CustomersViewModel;

        }

        public string CustomerCode
        {
            set
            {
                _viewModel = ViewModelLocator.CustomersViewModel;
                _viewModel.GetCustomerCommand.Execute(value);

                BindingContext = _viewModel;
            }
        }
    }
}