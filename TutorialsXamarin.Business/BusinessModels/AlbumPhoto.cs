using TutorialsXamarin.Common.Interfaces;


namespace TutorialsXamarin.Business.BusinessModels
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
