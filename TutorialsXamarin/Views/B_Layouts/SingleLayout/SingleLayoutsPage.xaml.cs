using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleLayoutsPage : ContentPage
    {
        public SingleLayoutsPage()
        {
            InitializeComponent();
        }

        private void btn_ScrollViewPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new NavigationPage(new ScrollViewPage()));
        }

        private void btn_FrameViewPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new NavigationPage(new FrameViewPage()));
        }

        private void btn_ContentView_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new NavigationPage(new ContentViewPage()));
        }
    }
}