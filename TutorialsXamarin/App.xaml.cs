using TutorialsXamarin.Business.Interfaces;
using TutorialsXamarin.Business.Managers;
using TutorialsXamarin.Common.Enums;
using TutorialsXamarin.Interfaces;
using TutorialsXamarin.Services;
using TutorialsXamarin.Utilities;
using TutorialsXamarin.Views;
using Xamarin.Forms;


namespace TutorialsXamarin
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class App : Application
    {
        public static ConnectionType ConnectionType =>ConnectionType.Mock;

        public App()
        {
            InitializeComponent();

            //Store All Views Names inside Navigation Service
            RegisterViews();
            
            //Using Xamarin Shell For Navigation
            MainPage = new AppShell();

            //MainPage = new MainPage();
            //MainPage = NavigationService.CreateNavigationPage(ViewsNames.HomePage);


            //==================================================================
            //Navigation -------------------------------------------------
            //==================================================================

            #region Navigations

            //Content Pages -----

            //MainPage = new NavigationPage(new ContentPageByXAML());
            //MainPage = new ContentPageByCode();


            //FullPage (Navigation Pages) -----
            //MainPage = new NavigationPage(new NavigationsPage());

            //Tabbed Pages -----
            //MainPage = new TabbedPageView();

            //Flyout Pages (Master Details) ------
            //MainPage = new HomePage();

            //Carousel Pages -----
            //MainPage = new NavigationPage(new CarouselPageView());

            #endregion


            //==================================================================
            //Layouts -------------------------------------------------
            //==================================================================

            #region Layouts


            //MainPage = new NavigationPage(new SingleLayoutsPage());


            //MainPage = new NavigationPage(new MultiLayoutsPage());

            #endregion

            //==================================================================
            //Views -------------------------------------------------
            //==================================================================

            #region Views


            //MainPage = new NavigationPage(new ViewsPage());

            #endregion

            //==================================================================
            //Resources -------------------------------------------------
            //==================================================================

            #region Resources

            //MainPage = new NavigationPage(new StaticResourcesPage());

            #endregion

            //==================================================================
            //Binding -------------------------------------------------
            //==================================================================

            #region Binding

            //MainPage = new NavigationPage(new DataBindingPage());

            //MainPage = new NavigationPage(new ViewBindingPage());

            //MainPage = new NavigationPage(new BindingModesPage());

            //MainPage = new NavigationPage(new CommandBindingPage());

            //MainPage = new NavigationPage(new BindingToObservableCollectionPage());

            #endregion

            //==================================================================
            //Styles Platform -------------------------------------------------
            //==================================================================

            #region Styles Platform

            //MainPage = new NavigationPage(new StylesPage());
            //MainPage = new NavigationPage(new CssStylesPage());

            #endregion

            //==================================================================
            //Web Services REST-FULL API
            //==================================================================

            #region REST Web API

            //MainPage = new NavigationPage(new CallWebAPiPage());
            //MainPage = new NavigationPage(new HttpGetRequestPage());

            #endregion

            //==================================================================
            //Xamarin Essential (For Native Cross Platform Features)-------
            //==================================================================

            #region Essential

            //MainPage = new NavigationPage(new XamarinEssenialPage());

            #endregion




        }

        protected override void OnStart() 
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        #region Dependency Injection

        public static ICustomerManager CustomersManager => new CustomerManager(App.ConnectionType);
        public static INavigationService NavigationService => new NavigationService();
        public static IMessagingCenter MessagingService => new MessagingService();
        

        #endregion

        #region Register Views

        private void RegisterViews()
        {
            //Store All Views Names inside Navigation Service
            NavigationService.Register(ViewsNames.HomePage, typeof(HomePage));

            NavigationService.Register(ViewsNames.AddCustomer, typeof(AddCustomer));
            NavigationService.Register(ViewsNames.ViewCustomer, typeof(ViewCustomer));
        }

        #endregion
    }
}
