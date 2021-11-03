using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorialsXamarin.Common.Models;
using Xamarin.Forms;

namespace TutorialsXamarin.ViewModels
{
    public class HttpGetRequestViewModel : BaseViewModel
    {
        //private readonly AlbumManager _albumManager;
        public HttpGetRequestViewModel()
        {
            //_albumManager = new AlbumManager();
        }

        #region Binding Properites

        public ObservableCollection<AlbumPhoto> Photos
        {
            get => _photos;
            set
            {
                if (_photos != value)
                {
                    _photos = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<AlbumPhoto> _photos;
      
        #endregion

        #region Binding Actions

        /// <summary>
        /// Get Full Name
        /// </summary>
        public ICommand GetAllPhotosCommand => _getAllPhotosCommand();
        private Command _getAllPhotosCommand()
        {
            return new Command(async ()=>
            {
                //Photos = await _albumManager.Get_All_Photos_Async();
                await Application.Current.MainPage.DisplayAlert("", "Photos Updates From Web Service","ok");
            });
        }

        #endregion

    }
}
