using System.Collections.Generic;
using System.Windows.Input;
using TutorialsXamarin.Common.Models;
using Xamarin.Forms;
using TutorialsXamarin.Views;

namespace TutorialsXamarin.ViewModels
{
    public class CoursesListViewMode:BaseViewModel
    {
        public CoursesListViewMode()
        {
            SelectedCourse = null;

            Fill_ListView_Courses();
            
            MessagingCenter.Subscribe<AddCoursePage, Course>(this, "AddCourseMessage", (sender, newAddedCourse) =>
            {
                Courses.Add(newAddedCourse);
            });

        }

        #region Binding Properites
        private List<Course> _courses;
        public List<Course> Courses
        {
            get => _courses;
            set
            {
                if (_courses != value)
                {
                    _courses = value;
                    OnPropertyChanged();
                }
            }
            
        }

        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                if (_selectedCourse != value)
                {
                    _selectedCourse = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    OnPropertyChanged();
                }
                
            }
        }

        #endregion

        #region Binding Actions

        public ICommand AddCoursePageCommand
        {
            get
            {
                return new Command(async () =>
                {
                   await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new AddCoursePage()));
                });
            }
        }

        public ICommand FillCoursesCommand
        {
            get
            {
                return new Command( ()=>
                {
                    if (Courses.Count > 0)
                    {
                        Fill_ListView_Courses();
                        IsRefreshing = false;
                    }
                });
            }
        }

        #endregion

        #region Helpers

        private void Fill_ListView_Courses()
        {
            //_coursesService = new CoursesService();

            //Courses = _coursesService.Get_All_Courses();

            Courses = new List<Course>
            {
                new Course{Id=1,Title="C#",Description="Learn C#.net",Price=100,Image="Chrome.png"},
                new Course{Id=1,Title="VB.Net",Description="Vb.Net Learning",Price=140,Image="Twitter.png"},
                new Course{Id=1,Title="Python",Description="Python is powerfull",Price=230,Image="Chrome.png"},
                new Course{Id=1,Title="Xamarin Forms",Description="Cross Platform",Price=120,Image="iTunes.png"},
                new Course{Id=1,Title="Xamarin Android",Description="Xamarin for android",Price=180,Image="Twitter.png"},
                new Course{Id=1,Title="Xamarin IOS",Description="Xamarin ios by csharp",Price=90,Image="Chrome.png"},
                new Course{Id=1,Title="Asp.Net Core",Description="asp.net core",Price=560,Image="iTunes.png"}
            };

        }

        #endregion
    }
}
