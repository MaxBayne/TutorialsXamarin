using System.Collections.Generic;
using SQLite;

namespace TutorialsXamarin.DataAccess.Models
{

    [Table("tbl_Albums")]
    public class Album
    {

        [PrimaryKey]
        [AutoIncrement]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        
        public List<AlbumPhoto> Photos { get; set; }
        
    }
}
