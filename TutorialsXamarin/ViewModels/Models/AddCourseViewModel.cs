using Xamarin.Forms;
using System.Windows.Input;
using TutorialsXamarin.Business.Models;

namespace TutorialsXamarin.ViewModels
{
    public class AddCourseViewModel : BaseViewModel
    {
        #region Binding Properites
        
        private Course _course;
        public Course Course
        {
            get => _course;
            set
            {
                if(_course != value)
                {
                    _course = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion

        #region Binding Actions

        /// <summary>
        /// Add new Course
        /// </summary>
        public ICommand AddCourseCommand => addCourseCommand();
        private Command addCourseCommand()
        {
            return new Command(() =>
            {
                Course = new Course()
                {
                    Title="",
                    Description="",
                    Price=0
                };
            });
        }

        #endregion
    }
}
