using System.Collections.Generic;

namespace TutorialsXamarin.Business.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }

        public List<AlbumPhoto> Photos { get; set; }
    }
}
