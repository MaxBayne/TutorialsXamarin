using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StylesPage
    {



        public StylesPage()
        {
            InitializeComponent();

            var style = new Style(typeof(Button));

            
            style.Setters.Add(new Setter {Property = Button.BackgroundColorProperty, Value = Color.Orange});
            style.Setters.Add(new Setter { Property = Button.TextColorProperty, Value = Color.White });

         
            BtnHardCodeStyle.Style = style;


        }

        private void BtnLightMode_OnClicked(object sender, EventArgs e)
        {
            this.Resources["PageStyle"] = this.Resources["LightStyle"];
        }

        private void BtnDarkMode_OnClicked(object sender, EventArgs e)
        {
            this.Resources["PageStyle"] = this.Resources["DarkStyle"];
        }
    }
}