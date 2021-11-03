using System;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceDisplayPage
    {
        public DeviceDisplayPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;

            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {

            DeviceDisplay.MainDisplayInfoChanged -= DeviceDisplay_MainDisplayInfoChanged;
            base.OnDisappearing();
        }



        //Device Display Info
        private void BtnDisplayInfo_OnClicked(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Orientation =  {DeviceDisplay.MainDisplayInfo.Orientation}");
            sb.AppendLine($"Density =  {DeviceDisplay.MainDisplayInfo.Density}");
            sb.AppendLine($"Height =  {DeviceDisplay.MainDisplayInfo.Height}");
            sb.AppendLine($"Width =  {DeviceDisplay.MainDisplayInfo.Width}");
            sb.AppendLine($"RefreshRate =  {DeviceDisplay.MainDisplayInfo.RefreshRate}");
            sb.AppendLine($"Rotation =  {DeviceDisplay.MainDisplayInfo.Rotation}");
            

            DisplayAlert("DisplayInfo", sb.ToString(),"Ok");
        }
        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            DisplayAlert("DisplayInfoChanged", e.DisplayInfo.ToString(), "Ok");
        }

        private void BtnKeepScreenOn_OnClicked(object sender, EventArgs e)
        {
            DeviceDisplay.KeepScreenOn = true;
        }
        private void BtnKeepScreenOff_OnClicked(object sender, EventArgs e)
        {
            DeviceDisplay.KeepScreenOn = false;
        }
    }
}