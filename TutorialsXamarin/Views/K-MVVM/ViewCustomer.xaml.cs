using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [QueryProperty(nameof(CustomerCode),"id")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCustomer
    {
        private readonly IViewCustomerViewModel _viewModel;

        public ViewCustomer(IViewCustomerViewModel viewCustomerViewModel)
        {
            InitializeComponent();

            //BindingContext = _viewModel = ViewModelLocator.ViewCustomerViewModel;
            BindingContext = _viewModel = viewCustomerViewModel;
        }

        public string CustomerCode
        {
            set => _viewModel.GetCustomerCommand.Execute(value);
        }
        
    }
}