using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using TutorialsXamarin.DependencyService;

namespace TutorialsXamarin.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {
        public PictureViewModel()
        {
            Title = "Pictures";

            //Check the Connectivity State for the Internet
            Connectivity.ConnectivityChanged += (sender,e)=> 
            {
                if(e.NetworkAccess != NetworkAccess)
                {
                    NetworkAccess = e.NetworkAccess;
                }

                if (e.NetworkAccess == NetworkAccess.Internet)
                {
                    Application.Current.MainPage.DisplayAlert("NetworkAccess", "Internet is available", "ok");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("NetworkAccess", "No Internet", "ok");
                }
            };
        }


        #region Binding Properites

        /// <summary>
        /// Hold Network Status
        /// </summary>
        public NetworkAccess NetworkAccess
        {
            get => _networkAccess;
            set
            {
                if (_networkAccess != value)
                {
                    _networkAccess = value;
                    OnPropertyChanged();
                }
                
            }
        }
        private NetworkAccess _networkAccess;

        /// <summary>
        /// Hold the Text of Page Title
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _title;

        
        /// <summary>
        /// Hold the state of Share Button enable/disable
        /// </summary>
        public bool EnabledShareButton
        {
            get => _enabledShareButton;
            set
            {
                if (_enabledShareButton != value)
                {
                    _enabledShareButton = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _enabledShareButton;

        
        /// <summary>
        /// Hold the state of Show Fix Button visible/invisible
        /// </summary>
        public bool ShowFixSettings
        {
            get => _showFixSettings;
            set
            {
                if (_showFixSettings != value)
                {
                    _showFixSettings = value;
                    OnPropertyChanged();
                }
                
            }
        }
        private bool _showFixSettings;

        
        /// <summary>
        /// Hold the Text of Button Label
        /// </summary>
        public string ButtonLabel 
        {
            get => _buttonLabel;
            set
            {
                if (_buttonLabel != value)
                {
                    _buttonLabel = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _buttonLabel = "Pick Picture";

        
        /// <summary>
        /// Hold the Image that Selected From PHoto Gallery
        /// </summary>
        public ImageSource ImageData
        {
            get => _imageData;
            set
            {
                if (_imageData != value)
                {
                    _imageData = value;
                    OnPropertyChanged();
                }
            }
        }
        private ImageSource _imageData;


        #endregion

        #region Binding Actions

        /// <summary>
        /// Pick up Photo From Gallery
        /// </summary>
        public ICommand PickPhotoCommand => new Command(async () => await PickPhotoAsync());
        

        /// <summary>
        /// Share Photo
        /// </summary>
        public ICommand ShareCommand => new Command(async () => await SharePhotoAsync(),()=>_enabledShareButton);
        
        /// <summary>
        /// Open Settings Page For Application
        /// </summary>
        public ICommand SettingsCommand => new Command(() => AppInfo.ShowSettingsUI());

        /// <summary>
        /// Toggle Keyboard Visibilty
        /// </summary>
        public ICommand ToggleKeyBoardCommand => _toggleKeyBoardCommand();
        private Command _toggleKeyBoardCommand()
        {
            return new Command(() =>
            {
               Xamarin.Forms.DependencyService.Get<IKeyboardHelper>().HideKeyboard();
            });
        }

        #endregion

        #region Helpers

        private async Task PickPhotoAsync()
        {
            //Check ths status of permission
            var permissionStatus = await Permissions.CheckStatusAsync<Permissions.Photos>();

            if (permissionStatus == PermissionStatus.Unknown)
            {
                //photo gallery permission not requested or granted from user then request it from user
                permissionStatus = await Permissions.RequestAsync<Permissions.Photos>();
            }
            else
            {
                var photoPicker = await Xamarin.Forms.DependencyService.Get<IPhotoShare>().GetPhotoShare();

                if (photoPicker != null)
                {
                    
                    ImageData = ImageSource.FromStream(()=> photoPicker.ImageContent);
                    EnabledShareButton = true;
                    
                }
            }

            //check the result of requested permission from user
            if (permissionStatus == PermissionStatus.Denied)
            {
                //user denied the requested permission , then print alert message to help him how to fix this again
                await Application.Current.MainPage.DisplayAlert("", "Photo Pick Denied - fix in Settings", "ok");

                //show the fix settings button so user can click it
                ShowFixSettings = true;
            }
            else
            {
                //user accept/grant the requested permission


                //hide fix settings button , user not need it
                ShowFixSettings = false;
            }

        }

        private Task SharePhotoAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
