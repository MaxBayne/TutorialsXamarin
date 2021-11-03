using SQLite;

namespace TutorialsXamarin.DataAccess.DataModels
{
    [Table("tbl_Album_Photos")]
    public class AlbumPhoto: Common.Models.AlbumPhoto
    {
        [PrimaryKey]
        [AutoIncrement]
        public new int Id { get; set; }
        
    }
}
