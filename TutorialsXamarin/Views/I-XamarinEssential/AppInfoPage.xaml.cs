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
    public partial class AppInfoPage : ContentPage
    {
        public AppInfoPage()
        {
            InitializeComponent();
        }

        private void BtnShowAppSettings_OnClicked(object sender, EventArgs e)
        {
            AppInfo.ShowSettingsUI();
        }

        private void BtnShowAppInfo_OnClicked(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"AppName = {AppInfo.Name}");
            sb.AppendLine($"PackageName = {AppInfo.PackageName}");
            sb.AppendLine($"RequestedTheme = {AppInfo.RequestedTheme.ToString()}");
            sb.AppendLine($"BuildString = {AppInfo.BuildString}");
            sb.AppendLine($"Version = {AppInfo.Version.ToString()}");
            sb.AppendLine($"VersionString = {AppInfo.VersionString}");
            
            DisplayAlert("AppInfo", sb.ToString(), "Ok");
        }
    }
}