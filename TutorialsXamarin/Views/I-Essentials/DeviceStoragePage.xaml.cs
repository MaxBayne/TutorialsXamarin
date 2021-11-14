using System;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceStoragePage
    {
        public DeviceStoragePage()
        {
            InitializeComponent();
        }

        //Preferences
        private void BtnSavePreferences_OnClicked(object sender, EventArgs e)
        {
            try
            {
                //Save Settings inside Default Preference File called [com.companynme.tutorialsxamarins_preferences.xml]
                //data/data/com.companyname.tutorialsxamarin/shared_prefs
                Preferences.Set("Phone", "01091281295");

                //Save Settings isside Preference File Called [UsersInfo.xml]
                Preferences.Set("UserId","100","UsersInfo");
                Preferences.Set("UserName", "Mohammed Salah", "UsersInfo");
                Preferences.Set("Email", "mail@gmail.com", "UsersInfo");

                DisplayAlert("Save Preferences", "Settings Saved", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Preferences", ex.Message, "ok");
            }
        }
        private void BtnReadPreferences_OnClicked(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"UserId = {Preferences.Get("UserId", "-", "UsersInfo")}");
                sb.AppendLine($"UserName = {Preferences.Get("UserName", "-", "UsersInfo")}");
                sb.AppendLine($"Email = {Preferences.Get("Email", "-", "UsersInfo")}");

                DisplayAlert("Read Preferences", sb.ToString(), "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Preferences", ex.Message, "ok");
            }
        }
        private void BtnClearPreferences_OnClicked(object sender, EventArgs e)
        {
            try
            {
                Preferences.Clear("UsersInfo");

                DisplayAlert("Clear Preferences", "Clear All Keys inside Container 'UsersInfo' ", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Preferences", ex.Message, "ok");
            }
        }
        private void BtnRemovePreferences_OnClicked(object sender, EventArgs e)
        {
            try
            {
                Preferences.Remove("UserId", "UsersInfo");
                Preferences.Remove("UserName", "UsersInfo");
                Preferences.Remove("Email", "UsersInfo");

                DisplayAlert("Remove Preferences", "Remove All Keys inside Container 'UsersInfo' ", "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Preferences", ex.Message, "ok");
            }
        }

        //Secure Storage
        private async void BtnSaveSecureStorage_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await SecureStorage.SetAsync("Password","P@ssword");

                await DisplayAlert("Save", "Settings Saved", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Secure Storage", ex.Message, "ok");
            }
        }
        private async void BtnReadSecureStorage_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var password = await SecureStorage.GetAsync("Password");

                await DisplayAlert("Read", password, "ok");

            }
            catch (Exception ex)
            {
                await DisplayAlert("SecureStorage", ex.Message, "ok");
            }
        }
        private void BtnClearSecureStorage_OnClicked(object sender, EventArgs e)
        {
            try
            {
                SecureStorage.Remove("Password");

                DisplayAlert("Remove", "Clear Key inside Secure Storage", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("SecureStorage", ex.Message, "ok");
            }
        }
        private void BtnRemoveSecureStorage_OnClicked(object sender, EventArgs e)
        {
            try
            {
                Preferences.Remove("UserId", "UsersInfo");
                Preferences.Remove("UserName", "UsersInfo");
                Preferences.Remove("Email", "UsersInfo");

                DisplayAlert("Remove", "Remove All Keys inside SecureStorage", "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("SecureStorage", ex.Message, "ok");
            }
        }

        //File System (CachedFile)
        //Cached File is Temp File can removed any ime by system
        private async void BtnCachedDirectory_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var cacheFile = Path.Combine(FileSystem.CacheDirectory,"file.txt");

                File.WriteAllText(cacheFile,"Hello World , its cached file");
                

                await DisplayAlert("CachedFile", cacheFile, "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("FileSystem", ex.Message, "ok");
            }
        }
        //File System (DataFile)
        //Data File is Data File that used to save local Application databases , system can backup its files
        private async void BtnDataDirectory_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var dataFile = Path.Combine(FileSystem.AppDataDirectory, "database.db");


                await DisplayAlert("DataFile", dataFile, "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("FileSystem", ex.Message, "ok");
            }
        }
        //File System (PackageFile)
        //File that stored inside folder Assets (Android), Resources (IOS) , UWP (Assets)
        private async void BtnPackageDirectory_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var cachedFile = Path.Combine(FileSystem.CacheDirectory, "Roqaya.jpg");
                var packageFile = await FileSystem.OpenAppPackageFileAsync("Roqaya.jpg");

                using (var fileStream = File.OpenWrite(cachedFile))
                {
                    await packageFile.CopyToAsync(fileStream);
                }

                await DisplayAlert("PackageFile", "Copy Assets File To Cached File", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("FileSystem", ex.Message, "ok");
            }
        }
    }
}