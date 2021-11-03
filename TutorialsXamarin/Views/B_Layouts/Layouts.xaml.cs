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
    public partial class Layouts : ContentPage
    {
        public Layouts()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.ClassId)
                {
                    case "SingleLayouts":
                        Navigation.PushModalAsync(new NavigationPage(new SingleLayoutsPage()));
                        break;

                    case "MultiLayouts":
                        Navigation.PushModalAsync(new NavigationPage(new MultiLayoutsPage()));
                        break;
                }
            }
        }
    }
}