using TutorialsXamarin.ViewModels;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MvvmPage
    {
        public MvvmPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.MvvmViewModel;
        }
    }
}