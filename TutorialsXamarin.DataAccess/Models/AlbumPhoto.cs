using SQLite;
using TutorialsXamarin.DataAccess.Interfaces;


namespace TutorialsXamarin.DataAccess.Models
{
    [Table("tbl_Album_Photos")]
    public class AlbumPhoto: IAlbumPhoto
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }

        public int AlbumId { get; set; }
    }
}
