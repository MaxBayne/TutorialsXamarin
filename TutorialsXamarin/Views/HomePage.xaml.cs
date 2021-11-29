using TutorialsXamarin.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        private readonly INavigationService _navigationService;

        public HomePage(INavigationService navigationService)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;

            _navigationService = navigationService;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HomePageFlyoutMenuItem;
            if (item == null)
                return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;
            //Detail = new NavigationPage(page);

            Detail = _navigationService.CreateNavigationPage(item.TargetType);
            
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}