
using TutorialsXamarin.Business.Models;

namespace TutorialsXamarin.ViewModels
{
    public class EditCourseViewModel : BaseViewModel
    {
        #region Binding Properites
        private Course _course;
        public Course Course
        {
            get => _course;
            set
            {
                if (_course!=value)
                {
                    _course = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Binding Actions

        #endregion
    }
}

