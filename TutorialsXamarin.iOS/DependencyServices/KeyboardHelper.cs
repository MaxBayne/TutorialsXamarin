using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TutorialsXamarin.DependencyService;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(TutorialsXamarin.iOS.DependencyServices.KeyboardHelper))]
namespace TutorialsXamarin.iOS.DependencyServices
{
    public class KeyboardHelper:IKeyboardHelper
    {
        public void HideKeyboard()
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
        }
    }
}