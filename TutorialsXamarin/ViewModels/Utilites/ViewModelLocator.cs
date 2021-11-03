namespace TutorialsXamarin.ViewModels
{
    public static class ViewModelLocator
    {
        public static MvvmViewModel MvvmViewModel { get; set; } = new MvvmViewModel(App.CustomersService);
    }
}
