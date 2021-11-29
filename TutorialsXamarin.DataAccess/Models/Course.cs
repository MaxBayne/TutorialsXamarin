
using SQLite;

namespace TutorialsXamarin.DataAccess.Models
{

    [Table("tbl_Courses")]
    public class Course
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Category { get; set; }
    }
}
