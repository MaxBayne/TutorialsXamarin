using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Android.Views.InputMethods;
using Plugin.CurrentActivity;
using TutorialsXamarin.DependencyService;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;

[assembly: Dependency(typeof(TutorialsXamarin.Droid.DependencyServices.KeyboardHelper))]
namespace TutorialsXamarin.Droid.DependencyServices
{
   
    public class KeyboardHelper:IKeyboardHelper
    {
        public void HideKeyboard()
        {
            var inputMethodManager = InputMethodManager.FromContext(CrossCurrentActivity.Current.AppContext);
        

            if (inputMethodManager != null)
            {
                inputMethodManager.HideSoftInputFromWindow(CrossCurrentActivity.Current.Activity.Window?.DecorView.WindowToken, HideSoftInputFlags.None);
            }
        }
    }
}