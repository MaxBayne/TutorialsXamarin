using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bindings : ContentPage
    {
        public Bindings()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.ClassId)
                {
                    case "DataBinding":
                        Navigation.PushModalAsync(new NavigationPage(new DataBindingPage()));
                        break;

                    case "ViewBinding":
                        Navigation.PushModalAsync(new NavigationPage(new ViewBindingPage()));
                        break;

                    case "BindingModes":
                        Navigation.PushModalAsync(new NavigationPage(new BindingModesPage()));
                        break;

                    case "CommandBinding":
                        Navigation.PushModalAsync(new NavigationPage(new CommandBindingPage()));
                        break;

                    case "ObservableBinding":
                        Navigation.PushModalAsync(new NavigationPage(new BindingToObservableCollectionPage()));
                        break;
                }
            }
        }
    }
}