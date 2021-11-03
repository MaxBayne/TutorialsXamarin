using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views.FlyoutPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageFlyout : ContentPage
    {
        public ListView ListView;

        public HomePageFlyout()
        {
            InitializeComponent();

            BindingContext = new HomePageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class HomePageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomePageFlyoutMenuItem> MenuItems { get; set; }

            public HomePageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<HomePageFlyoutMenuItem>(new[]
                {
                    new HomePageFlyoutMenuItem { Id = 0, Title = "Pages" ,TargetType = typeof(PagesTypes)},
                    new HomePageFlyoutMenuItem { Id = 1, Title = "Layouts" ,TargetType = typeof(Layouts)},
                    new HomePageFlyoutMenuItem { Id = 2, Title = "Views" ,TargetType = typeof(ViewsPage)},
                    new HomePageFlyoutMenuItem { Id = 3, Title = "Resources"  ,TargetType = typeof(Resources)},
                    new HomePageFlyoutMenuItem { Id = 4, Title = "Bindings"  ,TargetType = typeof(Bindings)},
                    new HomePageFlyoutMenuItem { Id = 5, Title = "Styles"  ,TargetType = typeof(Styles)},
                    new HomePageFlyoutMenuItem { Id = 6, Title = "Web Services"  ,TargetType = typeof(WebServices)},
                    new HomePageFlyoutMenuItem { Id = 7, Title = "Essential"  ,TargetType = typeof(XamarinEssenialPage)},
                    new HomePageFlyoutMenuItem { Id = 8, Title = "MVVM"  ,TargetType = typeof(MVVM)},
                    new HomePageFlyoutMenuItem { Id = 9, Title = "Others"  ,TargetType = typeof(Others)}
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}