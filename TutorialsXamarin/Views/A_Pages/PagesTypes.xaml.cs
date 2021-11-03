using System;
using TutorialsXamarin.Views.FlyoutPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagesTypes : ContentPage
    {
        public PagesTypes()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.ClassId)
                {
                    case "ContentByXaml":
                        Navigation.PushModalAsync(new NavigationPage(new ContentPageByXAML()));
                        break;

                    case "ContentByCode":
                        Navigation.PushModalAsync(new NavigationPage(new ContentPageByCode()));
                        break;

                    case "Flyout":
                        Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                        break;

                    case "Full":
                        Navigation.PushModalAsync(new NavigationPage(new NavigationsPage()));
                        break;

                    case "Tabbed":
                        Navigation.PushModalAsync(new NavigationPage(new TabbedPageView()));
                        break;

                    case "Carousel":
                        Navigation.PushModalAsync(new NavigationPage(new CarouselPageView()));
                        break;
                }
            }
        }
    }
}