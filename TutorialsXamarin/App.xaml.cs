using Autofac;
using TutorialsXamarin.Caching.Services;
using TutorialsXamarin.DependencyInjection.Services;
using TutorialsXamarin.Services;
using Xamarin.Forms;


namespace TutorialsXamarin
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class App : Application
    {
        /// <summary>
        /// Main Container that Hold All Dependency Components , use Scope From this and Avoid Resolve Direct From Container To Prevent Memory leaks 
        /// </summary>
        public static IContainer Container;

        //public static INavigationService NavigationService;

        public const string ApiUrl = "http://192.168.1.50/WebAPi/api/v1";

        public App()
        {
            InitializeComponent();

            //Configure Services -------------------------------------------------

            //Config Dependency Injection
            DependencyInjectionService.ConfigureDependency(ref Container);

            //Prepare Caching For System
            CachingService.ConfigCaching();

            //Prepare Navigation Service
            NavigationService.ConfigNavigation();

            
            //---------------------------------------------------------------------
            

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

    }
}
