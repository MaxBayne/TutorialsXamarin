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
    public partial class MVVM : ContentPage
    {
        public MVVM()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            switch (button?.StyleId)
            {
                case "BtnBasicMVVM":
                    Navigation.PushAsync(new MvvmPage());
                    break;
            }
        }
    }
}