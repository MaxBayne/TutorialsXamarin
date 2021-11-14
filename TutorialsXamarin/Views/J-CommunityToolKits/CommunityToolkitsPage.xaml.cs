using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommunityToolkitsPage
    {
        public CommunityToolkitsPage()
        {
            InitializeComponent();
        }

        private async void BtnAvatar_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AvatarViewPage());
        }
    }
}