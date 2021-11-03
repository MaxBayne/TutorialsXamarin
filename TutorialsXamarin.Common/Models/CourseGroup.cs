using System.Collections.ObjectModel;

namespace TutorialsXamarin.Common.Models
{
    public class CourseGroup : ObservableCollection<Course>
    {
        public string GroupName { get; }
        public string GroupShortName { get; }

        public CourseGroup(string groupName, string shortName)
        {
            GroupName = groupName;
            GroupShortName = shortName;
        }

    }
}
