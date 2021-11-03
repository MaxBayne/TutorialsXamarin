using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HttpGetRequestPage : ContentPage
    {
        private readonly HttpGetRequestViewModel vm;

        public HttpGetRequestPage()
        {
            InitializeComponent();

            BindingContext = vm = new HttpGetRequestViewModel();

        }
      
    }
}