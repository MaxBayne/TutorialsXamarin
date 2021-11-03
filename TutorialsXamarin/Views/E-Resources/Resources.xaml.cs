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
    public partial class Resources : ContentPage
    {
        public Resources()
        {
            InitializeComponent();
        }
        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.ClassId)
                {
                    case "StaticResources":
                        Navigation.PushModalAsync(new NavigationPage(new StaticResourcesPage()));
                        break;

                    case "DynamicResources":
                        Navigation.PushModalAsync(new NavigationPage(new DynamicResourcesPage()));
                        break;
                }
            }
        }
    }
}