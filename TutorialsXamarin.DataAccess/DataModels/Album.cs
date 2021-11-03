using SQLite;


namespace TutorialsXamarin.DataAccess.DataModels
{
    [Table("tbl_Albums")]
    public class Album:Common.Models.Album
    {
        [PrimaryKey]
        [AutoIncrement]
        public new int AlbumId { get; set; }
    
        
    }
}
