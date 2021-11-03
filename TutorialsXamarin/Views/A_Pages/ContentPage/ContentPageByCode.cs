using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TutorialsXamarin.Views
{
    public class ContentPageByCode : ContentPage
    {
        public ContentPageByCode()
        {
            Title = "ContentPageByCode";

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "This is Content Page By Code" }
                }
            };
        }
    }
}