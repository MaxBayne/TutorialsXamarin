using Xamarin.Forms;

namespace TutorialsXamarin.Utilities
{
    public class ShellDataTemplate:DataTemplateSelector
    {
        public DataTemplate HeaderDataTemplate { get; set; }
        public DataTemplate ItemDataTemplate { get; set; }
        public DataTemplate SplitterDataTemplate { get; set; }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is FlyoutItem flyoutItem)
            {
                //check if item is header or item

                if (flyoutItem.Route.Contains("header"))
                {
                    flyoutItem.IsEnabled = false;
                    return HeaderDataTemplate;
                }

                if(flyoutItem.Route.Contains("splitter"))
                {
                    flyoutItem.IsEnabled = false;
                    return SplitterDataTemplate;
                }

                
            }
            
            return ItemDataTemplate;
        }
    }
}