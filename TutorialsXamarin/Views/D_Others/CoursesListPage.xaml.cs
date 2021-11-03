using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesListPage : ContentPage
    {
        CoursesListViewMode _viewModel;

        public CoursesListPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new CoursesListViewMode();
        }

        public CoursesListPage(CoursesListViewMode viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        private void lsv_Courses_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var cash = lsv_Courses.CachingStrategy;
        }
    }
}