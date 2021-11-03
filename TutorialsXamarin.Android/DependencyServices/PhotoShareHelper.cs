using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.CurrentActivity;
using TutorialsXamarin.DependencyService;
using TutorialsXamarin.Droid.DependencyServices;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly:Dependency(typeof(PhotoShareHelper))]
namespace TutorialsXamarin.Droid.DependencyServices
{
    public class PhotoShareHelper : IPhotoShare
    {
        public Task<PhotoShare> GetPhotoShare()
        {
            Intent intent = new Intent();

            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            CrossCurrentActivity.Current.Activity.StartActivityForResult(Intent.CreateChooser(intent,"Select Image"),1000);

            MainActivity.MasterActivity.PickImageTask = new TaskCompletionSource<PhotoShare>();

            return MainActivity.MasterActivity.PickImageTask.Task;
        }
    }
}