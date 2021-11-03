using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.CurrentActivity;
using TutorialsXamarin.DependencyService;

namespace TutorialsXamarin.Droid
{
    [Activity(Label = "TutorialsXamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public TaskCompletionSource<PhotoShare> PickImageTask { get; set; }
        public static MainActivity MasterActivity { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            MasterActivity = this;

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            //Initial Xamarin Essentials To Work With This App
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            //Prepare Xamarin Essentials To Work With Permissions
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 1000)
            {
                //For Pick Image From Gallery
                if (resultCode == Result.Ok && data!=null)
                {
                    PickImageTask.SetResult(new PhotoShare()
                    {
                        ImageName = data.DataString,
                        ImageContent = ContentResolver?.OpenInputStream(data.Data!)
                    });
                }
                else
                {
                    PickImageTask.SetResult(null);
                }

            }
        }
    }
}