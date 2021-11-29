using System;
using TutorialsXamarin.Views;
using Xamarin.Forms;

namespace TutorialsXamarin
{
    
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Register Views For Route inside Shell
            Routing.RegisterRoute("customers",typeof(MvvmPage));
            Routing.RegisterRoute("viewcustomer", typeof(ViewCustomer));
            Routing.RegisterRoute("newcustomer", typeof(AddCustomer));
            
        }


        #region Menus Events

        private void MenuItem1_OnClicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            DisplayAlert("Message", "You Click Menu 1", "ok");
        }

        private void MenuItem2_OnClicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = true;
            DisplayAlert("Message", "You Click Menu 2", "ok");
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = true;
            DisplayAlert("Message", "You Click Menu", "ok");
        }


        #endregion

        #region Navigation Events

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            //DisplayAlert("OnNavigating", "OnNavigating", "ok");
        }
        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);

            //DisplayAlert("OnNavigated", "OnNavigated", "ok");
        }

        #endregion
    }
}