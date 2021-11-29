using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MVVM : ContentPage
    {
        private IMvvmViewModel _mvvmViewModel;
        public MVVM(IMvvmViewModel mvvmViewModel)
        {
            InitializeComponent();
            _mvvmViewModel = mvvmViewModel;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            switch (button?.StyleId)
            {
                case "BtnBasicMVVM":
                    Navigation.PushAsync(new MvvmPage(_mvvmViewModel));
                    break;
            }
        }
    }
}