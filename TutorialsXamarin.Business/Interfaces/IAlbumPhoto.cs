namespace TutorialsXamarin.Business.Interfaces
{
    public interface IAlbumPhoto
    {
        int Id { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        string ThumbnailUrl { get; set; }

        int AlbumId { get; set; }
    }
}
