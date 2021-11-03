using SQLite;

namespace TutorialsXamarin.DataAccess.DataModels
{
    [Table("tbl_Courses")]
    public class Course:Common.Models.Course
    {
        [PrimaryKey]
        [AutoIncrement]
        public new int Id { get; set; }
    }
}
