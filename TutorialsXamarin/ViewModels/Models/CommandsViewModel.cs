using System.Windows.Input;

using Xamarin.Forms;

namespace TutorialsXamarin.ViewModels
{
    public class CommandsViewModel: BaseViewModel
    {

        #region Binding Properites

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _firstName;

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _lastName;

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _fullName;

        #endregion

        #region Binding Actions

        /// <summary>
        /// Get Full Name
        /// </summary>
        public ICommand GetFullNameCommand => getFullNameCommand();
        private Command getFullNameCommand()
        {
            return new Command(()=>
            {
                FullName = _firstName + " " + _lastName;
            });
        }

        /// <summary>
        /// Clear Full Name
        /// </summary>
        public ICommand ClearFullNameCommand => clearFullNameCommand();
        private Command clearFullNameCommand()
        {
            return new Command(() =>
            {
                FullName = string.Empty;
            });
        }

        /// <summary>
        /// Clear All Fields
        /// </summary>
        public ICommand ClearAllCommand => clearAllCommand();
        private Command clearAllCommand()
        {
            return new Command(() =>
            {
                FirstName = string.Empty;
                LastName = string.Empty;
                FullName = string.Empty;
            });
        }


        /// <summary>
        /// Print Message
        /// </summary>
        public ICommand PrintCommand => printCommand();
        private Command printCommand()
        {
            return new Command((msg) =>
            {
                Application.Current.MainPage.DisplayAlert("Message", msg?.ToString(),"ok");
            });
        }


        #endregion

    }
}
