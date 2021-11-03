using System;

namespace TutorialsXamarin.ViewModels
{
    public class MenuItemViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Icon { get; set; }
        public Type Target { get; set; }    
    }
}
