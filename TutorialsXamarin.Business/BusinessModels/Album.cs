using System;
using System.Collections.Generic;
using System.Text;

namespace TutorialsXamarin.Business.BusinessModels
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }

        public List<AlbumPhoto> Photos { get; set; }
    }
}
