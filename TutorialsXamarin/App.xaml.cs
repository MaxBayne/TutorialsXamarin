﻿using TutorialsXamarin.Services;
using Xamarin.Forms;
using TutorialsXamarin.Views.FlyoutPage;


namespace TutorialsXamarin
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            MainPage = new HomePage();


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

        public static ICustomersService CustomersService { get; } = new CustomersService();

        #endregion
    }
}