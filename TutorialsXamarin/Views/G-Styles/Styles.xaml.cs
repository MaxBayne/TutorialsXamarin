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
    public partial class Styles : ContentPage
    {
        public Styles()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.ClassId)
                {
                    case "Styles":
                        Navigation.PushModalAsync(new NavigationPage(new StylesPage()));
                        break;

                    case "CssStyles":
                        Navigation.PushModalAsync(new NavigationPage(new CssStylesPage()));
                        break;

                   
                }
            }
        }
    }
}