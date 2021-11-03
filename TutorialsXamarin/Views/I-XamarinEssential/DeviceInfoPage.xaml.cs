using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceInfoPage : ContentPage
    {
        public DeviceInfoPage()
        {
            InitializeComponent();
        }

        private void BtnDeviceInfo_OnClicked(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"DeviceName =  {DeviceInfo.Name}");
            sb.AppendLine($"OperatingVersion =  {DeviceInfo.VersionString}");
            sb.AppendLine($"Manufacturer =  {DeviceInfo.Manufacturer}");
            sb.AppendLine($"Model =  {DeviceInfo.Model}");
            sb.AppendLine($"DeviceType =  {DeviceInfo.DeviceType}");
            sb.AppendLine($"Idiom =  {DeviceInfo.Idiom}");
            sb.AppendLine($"Platform =  {DeviceInfo.Platform}");

            DisplayAlert("DeviceInfo", sb.ToString(), "OK");
        }

        private void BtnIdiomInfo_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new DevicePlaforrm()));
        }
    }
}