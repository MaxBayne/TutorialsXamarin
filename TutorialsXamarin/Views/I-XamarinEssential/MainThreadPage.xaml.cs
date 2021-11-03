using System;
using System.Diagnostics;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainThreadPage
    {
        private readonly Timer _timer;
        public MainThreadPage()
        {
            InitializeComponent();

            _timer = new Timer(1000);
            _timer.AutoReset = true;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //Run Code inside Main Thread To Update UI Views
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    LblText.Text = DateTime.Now.ToLongTimeString();
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }



        private void BtnStartTimer_OnClicked(object sender, EventArgs e)
        {

            _timer.Start();

        }

        private void BtnStopTimer_OnClicked(object sender, EventArgs e)
        {

            _timer.Stop();

        }


    }
}