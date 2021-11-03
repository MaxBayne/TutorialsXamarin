using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TutorialsXamarin.Business.BusinessModels;
using TutorialsXamarin.DataAccess;

namespace TutorialsXamarin.Business.Managers
{
    public class AlbumManager
    {
        private readonly AlbumDa _albumDa;

        public AlbumManager()
        {
            _albumDa = new AlbumDa();
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
