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
    public partial class FirstNavigationPage : ContentPage
    {
        #region Passing Data With Constructor
        
        private string _PassingData;
        public string PassingData 
        {
            get=> _PassingData;
            set
            {
                _PassingData = value;

                txt_Data.Text = _PassingData;
            }
        }

        #endregion

        public FirstNavigationPage()
        {
            InitializeComponent();
        }

        public FirstNavigationPage(string passingData)
        {
            InitializeComponent();

            PassingData = passingData;
        }

        private async void btn_GoToHome_Clicked(object sender, EventArgs e)
        {
            //Remove Current Page For Navigation Stack Collection and Navigate To Root Home Screen
            //await Navigation.PopToRootAsync();

            //Go Home with Animation
            await Navigation.PopToRootAsync(true);
        }

        private async void btn_GoToPrevious_Clicked(object sender, EventArgs e)
        {
            //Remove Current Page For Navigation Stack Collection and Navigate To Previous Screen
            //await Navigation.PopAsync();

            //Go Back with Animation
            await Navigation.PopToRootAsync(true);
        }

        private async void btn_CloseModal_Clicked(object sender, EventArgs e)
        {
            //Close the Modal
            await Navigation.PopModalAsync();
        }
    }
}