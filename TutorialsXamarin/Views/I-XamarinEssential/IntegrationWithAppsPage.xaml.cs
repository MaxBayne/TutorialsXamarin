using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Color = System.Drawing.Color;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // ReSharper disable once RedundantExtendsListEntry
    public partial class IntegrationWithAppsPage : ContentPage
    {
        public IntegrationWithAppsPage()
        {
            InitializeComponent();
        }

        //الاتصال التليفوني
        //Phone Dialer
        private void BtnDialPhone_OnClicked(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("01091281295");
            }
            catch (Exception ex)
            {
                DisplayAlert("PhoneDialer", ex.Message, "ok");
            }
                
        }

        //ارسال رسالة اس ام اس
        //Send SMS
        private async void BtnSendSMS_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var message = new SmsMessage()
                {
                    Recipients = new List<string>
                    {
                        "01091281295",
                        "01154876454"
                    },
                    Body = "Hello World"

                };

                await Sms.ComposeAsync(message);
            }
            catch (Exception ex)
            {
                await DisplayAlert("SMS", ex.Message, "ok");
            }

        }

        //ارسال ايميل
        //Send Email
        private async void BtnSendEmail_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var email = new EmailMessage()
                {
                    To = new List<string> {"maxbayne@gmail.com"},
                    Cc = new List<string> { "maxbayne@gmail.com" },
                    Bcc = new List<string> { "maxbayne@gmail.com" },
                    Subject = "Test Email",
                    Body = "<u>Hello</u> World <b>Email</b>",
                    BodyFormat = EmailBodyFormat.Html
                };

                await Email.ComposeAsync(email);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Email", ex.Message, "ok");
            }

        }

        //فتح الخريطة
        //Open Map as Default Navigation
        private async void BtnOpenMapDefault_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Map.OpenAsync(new Location
                {
                    Longitude = 30.473974942456543,
                    Latitude = 31.26242033636416

                },new MapLaunchOptions
                {
                    Name = "My Home",
                    NavigationMode = NavigationMode.Default
                });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Map", ex.Message, "ok");
            }

        }
        //فتح الخريطة
        //Open Map as Driving Navigation
        private async void BtnOpenMapDriving_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Map.OpenAsync(new Location
                {
                    Longitude = 30.473974942456543,
                    Latitude = 31.26242033636416

                }, new MapLaunchOptions
                {
                    Name = "My Home",
                    NavigationMode = NavigationMode.Driving
                });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Map", ex.Message, "ok");
            }

        }
        //فتح الخريطة
        //Open Map as Bicycling Navigation
        private async void BtnOpenMapBicycling_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Map.OpenAsync(new Location
                {
                    Longitude = 30.473974942456543,
                    Latitude = 31.26242033636416

                }, new MapLaunchOptions
                {
                    Name = "My Home",
                    NavigationMode = NavigationMode.Bicycling
                });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Map", ex.Message, "ok");
            }

        }
        //فتح الخريطة
        //Open Map as Walking Navigation
        private async void BtnOpenMapWalking_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Map.OpenAsync(new Location
                {
                    Longitude = 30.473974942456543,
                    Latitude = 31.26242033636416

                }, new MapLaunchOptions
                {
                    Name = "My Home",
                    NavigationMode = NavigationMode.Walking
                });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Map", ex.Message, "ok");
            }

        }
        //فتح الخريطة
        //Open Map as Transit Navigation
        private async void BtnOpenMapTransit_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Map.OpenAsync(new Location
                {
                    Longitude = 30.473974942456543,
                    Latitude = 31.26242033636416

                }, new MapLaunchOptions
                {
                    Name = "My Home",
                    NavigationMode = NavigationMode.Transit
                });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Map", ex.Message, "ok");
            }

        }
        //فتح الخريطة
        //Open Map as None Navigation
        private async void BtnOpenMapNone_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Map.OpenAsync(new Location
                {
                    Longitude = 30.473974942456543,
                    Latitude = 31.26242033636416

                }, new MapLaunchOptions
                {
                    Name = "My Home",
                    NavigationMode = NavigationMode.None
                });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Map", ex.Message, "ok");
            }

        }

        //فتح المتصفح
        //Open Browser as SystemPreferred
        private async void BtnOpenBrowser1_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.google.com", new BrowserLaunchOptions
                {
                    LaunchMode = BrowserLaunchMode.SystemPreferred,
                    PreferredToolbarColor = Color.Blue,
                    PreferredControlColor = Color.Red,
                    TitleMode = BrowserTitleMode.Show
                });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Map", ex.Message, "ok");
            }

        }
        //فتح المتصفح
        //Open Browser as External App
        private async void BtnOpenBrowser2_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.google.com", new BrowserLaunchOptions
                {
                    LaunchMode = BrowserLaunchMode.External,
                    TitleMode = BrowserTitleMode.Hide
                });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Map", ex.Message, "ok");
            }

        }

        //فتح التطبيق
        //Open Launcher 1
        private async void BtnOpenApp1_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Launcher.OpenAsync(new Uri("https://www.google.com",UriKind.RelativeOrAbsolute));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Launcher", ex.Message, "ok");
            }

        }
        //فتح التطبيق
        //Open Launcher 2
        private async void BtnOpenApp2_OnClicked(object sender, EventArgs e)
        {
            try
            {

                await Launcher.OpenAsync(new Uri("com.google.android.deskclock", UriKind.RelativeOrAbsolute));
                //await Launcher.OpenAsync(new OpenFileRequest());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Launcher", ex.Message, "ok");
            }

        }

        //مشاركة النص
        //Share Text
        private async void BtnShareText_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Share.RequestAsync(new ShareTextRequest
                {
                    Title = "ShareTitle For Text",
                    Text = "This is My Message To Share",
                    Subject = "Share Subject",
                    Uri = "maxbayne@gmail.com"
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Share", ex.Message, "ok");
            }
        }
        //مشاركة الملف
        //Share File
        private async void BtnShareFile_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Share.RequestAsync(new ShareFileRequest()
                {
                    Title = "ShareTitle For File",
                    File = new ShareFile("Chrome.png")
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Share", ex.Message, "ok");
            }

        }


        //نسخ النص
        //Copy Text To Clipboard
        private async void BtnCopyText_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Clipboard.SetTextAsync("Welcome TO Xamarin");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Clipboard", ex.Message, "ok");
            }

        }
        //لصق النص
        //Get Text From Clipboard
        private async void BtnPastText_OnClicked(object sender, EventArgs e)
        {
            try
            {

                if (Clipboard.HasText)
                {
                    var text = await Clipboard.GetTextAsync();

                    await DisplayAlert("Read From Clipboard", text, "ok");
                }
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Clipboard", ex.Message, "ok");
            }

        }




    }
}