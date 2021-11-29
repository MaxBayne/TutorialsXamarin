using Autofac;
using TutorialsXamarin.ViewModels;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MvvmPage
    {
        private IMvvmViewModel _mvvmViewModel;
        public MvvmPage(IMvvmViewModel mvvmViewModel)
        {
            InitializeComponent();

            BindingContext=_mvvmViewModel = mvvmViewModel;
            
        }
        public MvvmPage()
        {
            InitializeComponent();

            using (var scope = App.Container.BeginLifetimeScope())
            {
                _mvvmViewModel = scope.Resolve<IMvvmViewModel>();

                BindingContext = _mvvmViewModel;
            }

            //BindingContext = _mvvmViewModel = mvvmViewModel;

        }
    }
}