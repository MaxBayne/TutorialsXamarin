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
    public partial class NavigationsPage : ContentPage
    {
        public NavigationsPage()
        {
            InitializeComponent();

        }

        private async void btn_GoToFirst_Clicked(object sender, EventArgs e)
        {
            //Add FirstNaviagtionPage To Navigation Stack Collection and Navigate to it
            //await this.Navigation.PushAsync(new FirstNavigationPage());

            //Navigation with Animation (default state is animation enabled)
            //await this.Navigation.PushAsync(new FirstNavigationPage());

            //Navigation without Animation
            await this.Navigation.PushAsync(new FirstNavigationPage(), false);
            
            //await this.Navigation.PushModalAsync(new ContentPageByXAML()); //open page as modal
        }

        private async void btn_GoToSecond_Clicked(object sender, EventArgs e)
        {
            //Add SecondNaviagtionPage To Navigation Stack Collection and Navigate to it
            await this.Navigation.PushAsync(new SecondNavigationPage());

            //await this.Navigation.PushModalAsync(new ContentPageByCode()); //open page as modal
        }

        private async void btn_GoToFirstWithPassingDataThrowConstructor_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new FirstNavigationPage("Hello , Iam Data From Home Page"));

            //Or

            //await this.Navigation.PushAsync(new FirstNavigationPage 
            //{
            //    PassingData="Hello World"
            //});

            //Or

            //var firstPage = new FirstNavigationPage();

            //firstPage.PassingData = "Hello Max Bayne";

            //await this.Navigation.PushAsync(firstPage);
        }

        private async void btn_GoToFirstWithPassingDataThrowBindingContext_Clicked(object sender, EventArgs e)
        {
            //Passing Data Using ViewModel and Binding Context

            var firstPage = new FirstNavigationPage();
            var firstPageViewModel = firstPage.BindingContext as FirstPageViewModel;

            firstPageViewModel.Message = "Hello From ViewModel";

            await this.Navigation.PushAsync(firstPage);
        }

        private async void btn_OpenModalPage_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new FirstNavigationPage());
        }
    }
}