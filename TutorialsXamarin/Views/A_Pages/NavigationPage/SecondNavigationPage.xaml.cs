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
    public partial class SecondNavigationPage : ContentPage
    {
        public SecondNavigationPage()
        {
            InitializeComponent();
        }

        private async void btn_GoToHome_Clicked(object sender, EventArgs e)
        {
            //Remove Current Page For Navigation Stack Collection and Navigate To Root Home Screen
            await Navigation.PopToRootAsync();
        }

        private async void btn_GoToPrevious_Clicked(object sender, EventArgs e)
        {
            //Remove Current Page For Navigation Stack Collection and Navigate To Previous Screen
            await Navigation.PopAsync();
        }
    }
}