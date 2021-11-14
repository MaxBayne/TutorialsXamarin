using System;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XamarinEssenialPage
    {
        //Constructor
        public XamarinEssenialPage()
        {
            InitializeComponent();
        }


        private async void BtnDeviceServices_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceServicesPage());
        }

        private async void BtnDeviceSensors_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceSensorsPage());
        }

        private async void BtnIntegwithApp_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IntegrationWithAppsPage());
        }

        private async void BtnDeviceStorage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceStoragePage());
        }

        private async void BtnDeviceInfo_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceInfoPage());
        }

        private async void BtnDeviceDisplay_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceDisplayPage());
        }

        private async void BtnAppInfo_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppInfoPage());
        }

        private async void BtnMainThread_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainThreadPage());
        }
        private async void BtnVersionTracker_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VersionTrackingPage());
        }

        
    }
}