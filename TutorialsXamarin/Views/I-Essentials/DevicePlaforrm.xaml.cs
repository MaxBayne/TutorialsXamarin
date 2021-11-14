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
    public partial class DevicePlaforrm : ContentPage
    {
        public DevicePlaforrm()
        {
            InitializeComponent();



            //Detect the Device Type -------------------


            //Device.Idiom ==TargetIdiom.Desktop
            //Device.Idiom == TargetIdiom.Phone
            //Device.Idiom == TargetIdiom.Tablet
            //Device.Idiom == TargetIdiom.TV
            //Device.Idiom == TargetIdiom.Watch

            //if (Device.Idiom == TargetIdiom.Phone)
            //{
            //    lbl_Title.BackgroundColor = Color.Yellow;
            //}
            //else
            //{
            //    lbl_Title.BackgroundColor = Color.Silver;
            //}



            //Detect the Device System ---------------------
            //Device.Android
            //Device.iOS
            //Device.UWP
            //Device.macOS
            //Device.GTK
            //Device.Tizen
            //Device.WPF

            //switch (Device.RuntimePlatform)
            //{
            //    case Device.Android:
            //        break;
            //    case Device.iOS:
            //        break;
            //    case Device.UWP:

            //    default:
            //        break;
            //}
        }

        private bool _EnableTimer = false;

        private void btn_StartTimer_Clicked(object sender, EventArgs e)
        {
            _EnableTimer = true;

            //Start Timer run every one second and invoke action every one second
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                //Run Method on Main UI Thread ,using for update UI Controls
                Device.BeginInvokeOnMainThread(() =>
                    {
                        lbl_Timer.Text = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}"; ;
                    });

                return _EnableTimer;
            });
        }

        private void btn_StopTimer_Clicked(object sender, EventArgs e)
        {
            _EnableTimer = false;
        }
    }
}