using TutorialsXamarin.Business.Interfaces;


namespace TutorialsXamarin.Business.Models
{
    public class AlbumPhoto: IAlbumPhoto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }

        public int AlbumId { get; set; }
    }
}
