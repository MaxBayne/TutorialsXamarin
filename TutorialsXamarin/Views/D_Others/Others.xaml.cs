using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Others : ContentPage
    {
        public Others()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.ClassId)
                {
                    case "CoursesList":
                        Navigation.PushModalAsync(new NavigationPage(new CoursesListPage()));
                        break;

                    case "AddCourse":
                        Navigation.PushModalAsync(new NavigationPage(new AddCoursePage()));
                        break;
                }
            }
        }
    }
}