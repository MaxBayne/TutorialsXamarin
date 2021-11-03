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
    public partial class WebServices : ContentPage
    {
        public WebServices()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.ClassId)
                {
                    case "CallWebAPiPage":
                        Navigation.PushModalAsync(new NavigationPage(new StylesPage()));
                        break;

                    case "HttpGetRequest":
                        Navigation.PushModalAsync(new NavigationPage(new CssStylesPage()));
                        break;


                }
            }
        }
    }
}