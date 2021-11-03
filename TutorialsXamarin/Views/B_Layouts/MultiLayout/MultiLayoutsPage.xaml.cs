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
    public partial class MultiLayoutsPage : ContentPage
    {
        public MultiLayoutsPage()
        {
            InitializeComponent();
        }

        private void btn_StackLayout_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new StackLayout1());
        }

        private void btn_GridLayout_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new GridLayout1());
        }

        private void btn_RelativeLayout_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new RelativeLayout1());
        }

        private void btn_AbsoluteLayout_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new AbsoluteLayoutPage());
        }

        private void btn_FlexLayout_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new FlexLayoutPage());
        }
    }
}