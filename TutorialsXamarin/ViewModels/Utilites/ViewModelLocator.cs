// ReSharper disable once CheckNamespace
namespace TutorialsXamarin.ViewModels
{
    public static class ViewModelLocator
    {
        //Register All ViewModels Here To Can Use anywhere inside App


        #region MVVM

        public static MvvmViewModel MvvmViewModel { get; set; } = new MvvmViewModel(App.CustomersManager,App.NavigationService,App.MessagingService);

        public static CustomersViewModel CustomersViewModel { get; set; } = new CustomersViewModel(App.CustomersManager);

        #endregion

    }
}
