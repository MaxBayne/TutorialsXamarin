using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TutorialsXamarin.Business.Models;
using TutorialsXamarin.Common.Enums;
using TutorialsXamarin.DataAccess.Da;

namespace TutorialsXamarin.Business.Managers
{
    public class AlbumManager
    {
        private readonly AlbumDa _albumDa;

        public AlbumManager(ConnectionType connectionType)
        {
            _albumDa = new AlbumDa(connectionType);
        }

        public async Task<ObservableCollection<AlbumPhoto>> Get_All_Photos_Async()
        {
            var photos =await _albumDa.Get_All_Photos_Async();

            var lstPhotos = new ObservableCollection<AlbumPhoto>();

            foreach (var photo in photos)
            {
                lstPhotos.Add(new AlbumPhoto
                {
                    Id = photo.Id,
                    Title = photo.Title,
                    Url = photo.Url,
                    ThumbnailUrl = photo.ThumbnailUrl,
                    AlbumId = photo.AlbumId
                });
            }

            return lstPhotos;
        }
    }
}
