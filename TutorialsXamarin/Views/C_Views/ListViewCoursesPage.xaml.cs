using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TutorialsXamarin.Common.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewCoursesPage
    {
        public ListViewCoursesPage()
        {
            InitializeComponent();

            LvCourses.ItemsSource = GetCoursesWithGroup();
        }
        

        private async void LvCourses_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var course = e.SelectedItem as Course;

            await DisplayAlert("Item Selected", course?.Title, "ok");
        }

        private async void LvCourses_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var course = e.Item as Course;

            await DisplayAlert("Item Tapped", course?.Description, "ok");
        }

        private void LvCourses_OnRefreshing(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await Task.Delay(3000);

                LvCourses.EndRefresh();
            });
            
        }

        #region Helper

        private ObservableCollection<Course> GetCourses()
        {
            return new ObservableCollection<Course>
            {
                new Course
                {
                    Id = 100,
                    Title = "Xamarin",
                    Description = "Xamarin Forms",
                    Image = "Chrome.png",
                    Price = 1500,
                    Category = "Mobile"
                },
                new Course
                {
                    Id = 200,
                    Title = "Asp.net",
                    Description = "Learn Asp.net Core",
                    Image = "iTunes.png",
                    Price = 874,
                    Category = "Web"
                },
                new Course
                {
                    Id = 300,
                    Title = "C#",
                    Description = "Learn C# .net",
                    Image = "Twitter.png",
                    Price = 1212,
                    Category = "Desktop"
                },
                new Course
                {
                    Id = 400,
                    Title = "F#",
                    Description = "Learn F# .net",
                    Image = "iTunes.png",
                    Price = 888,
                    Category = "Other"
                },
                new Course
                {
                    Id = 500,
                    Title = "Android",
                    Description = "Learn Android",
                    Image = "Twitter.png",
                    Price = 444,
                    Category = "Mobile"
                },
                new Course
                {
                    Id = 600,
                    Title = "IOS",
                    Description = "Learn IOS",
                    Image = "Chrome.png",
                    Price = 1500,
                    Category = "Mobile"
                },
                new Course
                {
                    Id = 700,
                    Title = "WPF",
                    Description = "Learn WPF",
                    Image = "Twitter.png",
                    Price = 455,
                    Category = "Desktop"
                },
                new Course
                {
                    Id = 800,
                    Title = "Arduino",
                    Description = "Learn Arduino",
                    Image = "Chrome.png",
                    Price = 331,
                    Category = "IOT"
                },
                new Course
                {
                    Id = 900,
                    Title = "Raspery PI",
                    Description = "Learn Raspery",
                    Image = "Twitter.png",
                    Price = 468,
                    Category = "IOT"
                }
            };
        }
        private ObservableCollection<CourseGroup> GetCoursesWithGroup()
        {
            return new ObservableCollection<CourseGroup>
            {
                new CourseGroup("Mobile","MOB")
                {
                    new Course
                    {
                        Id = 100,
                        Title = "Xamarin",
                        Description = "Xamarin Forms",
                        Image = "Chrome.png",
                        Price = 1500
                    },
                    new Course
                    {
                        Id = 500,
                        Title = "Android",
                        Description = "Learn Android",
                        Image = "Twitter.png",
                        Price = 444
                    },
                    new Course
                    {
                        Id = 600,
                        Title = "IOS",
                        Description = "Learn IOS",
                        Image = "Chrome.png",
                        Price = 1500
                    },
                    new Course
                    {
                        Id = 600,
                        Title = "Fluitter",
                        Description = "Learn Fluitter",
                        Image = "Chrome.png",
                        Price = 1400
                    },
                    new Course
                    {
                        Id = 600,
                        Title = "Kottlen",
                        Description = "Learn Kottlen",
                        Image = "Chrome.png",
                        Price = 1400
                    }
                },
                new CourseGroup("Desktop","DSK")
                {
                    new Course
                    {
                        Id = 300,
                        Title = "C#",
                        Description = "Learn C# .net",
                        Image = "Twitter.png",
                        Price = 1212
                    },
                    new Course
                    {
                        Id = 700,
                        Title = "WPF",
                        Description = "Learn WPF",
                        Image = "Twitter.png",
                        Price = 455
                    },
                    new Course
                    {
                    Id = 700,
                    Title = "Win Forms",
                    Description = "Learn Windows Forms",
                    Image = "Twitter.png",
                    Price = 250
                }
                },
                new CourseGroup("Web","WEB")
                {
                    new Course
                    {
                        Id = 200,
                        Title = "Asp.net",
                        Description = "Learn Asp.net Core",
                        Image = "iTunes.png",
                        Price = 874
                    },
                    new Course
                    {
                        Id = 200,
                        Title = "PHP",
                        Description = "Learn PHP",
                        Image = "iTunes.png",
                        Price = 874
                    }

                },
                new CourseGroup("Internet Of Things","IOT")
                {
                    new Course
                    {
                        Id = 800,
                        Title = "Arduino",
                        Description = "Learn Arduino",
                        Image = "Chrome.png",
                        Price = 331
                    },
                    new Course
                    {
                        Id = 900,
                        Title = "Raspery PI",
                        Description = "Learn Raspery",
                        Image = "Twitter.png",
                        Price = 468
                    }
                },
                new CourseGroup("Other","Other")
                {
                    new Course
                    {
                        Id = 400,
                        Title = "F#",
                        Description = "Learn F# .net",
                        Image = "iTunes.png",
                        Price = 888
                    },
                    new Course
                    {
                        Id = 400,
                        Title = "Electronic",
                        Description = "Learn Electronic",
                        Image = "iTunes.png",
                        Price = 888
                    }
                }
            };
        }

        #endregion
    }
}