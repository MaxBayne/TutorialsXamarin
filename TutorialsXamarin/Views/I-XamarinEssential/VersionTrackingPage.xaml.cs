using System;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VersionTrackingPage
    {
        public VersionTrackingPage()
        {
            InitializeComponent();
        }

        private void BtnVersionTraker_OnClicked(object sender, EventArgs e)
        {
            VersionTracking.Track();

            string previousVersions=string.Empty;
            VersionTracking.VersionHistory?.ForEach((version) => previousVersions += $"{version} ,");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"FirstInstalledBuild={VersionTracking.FirstInstalledBuild}");
            sb.AppendLine($"CurrentBuild={VersionTracking.CurrentBuild}");
            sb.AppendLine($"CurrentVersion={VersionTracking.CurrentVersion}");
            sb.AppendLine($"FirstInstalledVersion={VersionTracking.FirstInstalledVersion}");
            sb.AppendLine($"IsFirstLaunchEver={VersionTracking.IsFirstLaunchEver}");
            sb.AppendLine($"IsFirstLaunchForCurrentBuild={VersionTracking.IsFirstLaunchForCurrentBuild}");
            sb.AppendLine($"IsFirstLaunchForCurrentVersion={VersionTracking.IsFirstLaunchForCurrentVersion}");
            sb.AppendLine($"PreviousBuild={VersionTracking.PreviousBuild}");
            sb.AppendLine($"PreviousVersion={VersionTracking.PreviousVersion}");
            sb.AppendLine($"VersionHistory={previousVersions}");


            DisplayAlert("VersionInfo", sb.ToString(), "Ok");
        }
    }
}