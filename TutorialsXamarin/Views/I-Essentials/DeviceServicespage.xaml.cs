using System;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceServicesPage
    {
        public DeviceServicesPage()
        {
            InitializeComponent();
        }

        //Fire On Appear UI
        protected override void OnAppearing()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            Battery.EnergySaverStatusChanged += Battery_EnergySaverStatusChanged;
            base.OnAppearing();
        }



        //Fire On Disappear UI
        protected override void OnDisappearing()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
            Battery.BatteryInfoChanged -= Battery_BatteryInfoChanged;
            Battery.EnergySaverStatusChanged -= Battery_EnergySaverStatusChanged;
            base.OnDisappearing();
        }

        //Geo Location
        private async void BtnGeoLocation_OnClicked(object sender, EventArgs e)
        {
            try
            {

                var currentLocation = await Geolocation.GetLastKnownLocationAsync() ?? await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best));


                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine($"Altitude : {currentLocation.Altitude}");
                strBuilder.AppendLine($"Latitude : {currentLocation.Latitude}");
                strBuilder.AppendLine($"Longitude : {currentLocation.Longitude}");
                strBuilder.AppendLine($"Course : {currentLocation.Course}");
                strBuilder.AppendLine($"Speed : {currentLocation.Speed}");
                strBuilder.AppendLine($"Timestamp : {currentLocation.Timestamp}");
                strBuilder.AppendLine($"IsFromMockProvider : {currentLocation.IsFromMockProvider}");
                strBuilder.AppendLine($"HorizontalAccuracy : {currentLocation.Accuracy}");
                strBuilder.AppendLine($"VerticalAccuracy : {currentLocation.VerticalAccuracy}");

                //Distance Between Current Location and Another Location
                strBuilder.AppendLine($"Distance (KM) : {currentLocation.CalculateDistance(new Location(30.4656053, 31.2471153), DistanceUnits.Kilometers)}");


                await DisplayAlert("GeoLocation", strBuilder.ToString(), "ok");

            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("FeatureNotSupportedException", ex.Message, "ok");
            }
            catch (FeatureNotEnabledException ex)
            {
                await DisplayAlert("FeatureNotEnabledException", ex.Message, "ok");
            }
            catch (PermissionException ex)
            {
                await DisplayAlert("PermissionException", ex.Message, "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
            }




        }
        private async void BtnConvertLocationToAddress_OnClicked(object sender, EventArgs e)
        {
            try
            {

                var currentLocation = await Geolocation.GetLastKnownLocationAsync() ?? await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best));

                var addresses = await Geocoding.GetPlacemarksAsync(currentLocation);
                addresses = addresses.ToList();
                var placemarks = addresses.ToList();
                var address = placemarks.FirstOrDefault();

                if (address != null)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.AppendLine($"AddressesCount : {placemarks.Count()}");
                    strBuilder.AppendLine($"AdminArea : {address.AdminArea}");
                    strBuilder.AppendLine($"SubAdminArea : {address.SubAdminArea}");
                    strBuilder.AppendLine($"CountryCode : {address.CountryCode}");
                    strBuilder.AppendLine($"CountryName : {address.CountryName}");
                    strBuilder.AppendLine($"FeatureName : {address.FeatureName}");
                    strBuilder.AppendLine($"Locality : {address.Locality}");
                    strBuilder.AppendLine($"SubLocality : {address.SubLocality}");
                    strBuilder.AppendLine($"PostalCode : {address.PostalCode}");
                    strBuilder.AppendLine($"Thoroughfare : {address.Thoroughfare}");
                    strBuilder.AppendLine($"SubThoroughfare : {address.SubThoroughfare}");


                    await DisplayAlert("GeoCoding.GetPlaceMark", strBuilder.ToString(), "ok");
                }

            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("FeatureNotSupportedException", ex.Message, "ok");
            }
            catch (FeatureNotEnabledException ex)
            {
                await DisplayAlert("FeatureNotEnabledException", ex.Message, "ok");
            }
            catch (PermissionException ex)
            {
                await DisplayAlert("PermissionException", ex.Message, "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
            }

        }
        private async void BtnConvertAddressToLocation_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync("شبلنجة");
                locations = locations.ToList();
                var enumerable = locations.ToList();
                var location = enumerable.FirstOrDefault();

                if (location != null)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.AppendLine($"LocationsCount : {enumerable.Count()}");

                    strBuilder.AppendLine($"Latitude : {location.Latitude}");
                    strBuilder.AppendLine($"Longitude : {location.Longitude}");


                    await DisplayAlert("GeoCoding.GetLocation", strBuilder.ToString(), "ok");
                }

            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("FeatureNotSupportedException", ex.Message, "ok");
            }
            catch (FeatureNotEnabledException ex)
            {
                await DisplayAlert("FeatureNotEnabledException", ex.Message, "ok");
            }
            catch (PermissionException ex)
            {
                await DisplayAlert("PermissionException", ex.Message, "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
            }
        }

        //Geo Coding
        private async void BtnCheckConnectivity_OnClicked(Object sender, EventArgs e)
        {
            //Need Permission Called [Access_Network_State]

            try
            {

                switch (Connectivity.NetworkAccess)
                {
                    case NetworkAccess.None:
                        await DisplayAlert("Connectivity", "No Connection", "ok");
                        break;

                    case NetworkAccess.Unknown:
                        await DisplayAlert("Connectivity", "No Connection", "ok");

                        break;

                    case NetworkAccess.Local:
                        await DisplayAlert("Connectivity", "Local Connection", "ok");
                        break;

                    case NetworkAccess.ConstrainedInternet:
                        await DisplayAlert("Connectivity", "Limited Connection", "ok");
                        break;

                    case NetworkAccess.Internet:
                        await DisplayAlert("Connectivity", "Internet", "ok");
                        break;
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
            }
        }
        private async void BtnGetConnectionType_OnClicked(Object sender, EventArgs e)
        {
            //Need Permission Called [Access_Network_State]

            try
            {

                switch (Connectivity.ConnectionProfiles.FirstOrDefault())
                {
                    case ConnectionProfile.Unknown:
                        await DisplayAlert("ConnectionProfile", "Unknown", "ok");
                        break;

                    case ConnectionProfile.WiFi:
                        await DisplayAlert("ConnectionProfile", "WiFi", "ok");
                        break;

                    case ConnectionProfile.Cellular:
                        await DisplayAlert("ConnectionProfile", "Cellular", "ok");
                        break;

                    case ConnectionProfile.Bluetooth:
                        await DisplayAlert("ConnectionProfile", "Bluetooth", "ok");
                        break;

                    case ConnectionProfile.Ethernet:
                        await DisplayAlert("ConnectionProfile", "Ethernet", "ok");
                        break;

                    default:
                        await DisplayAlert("ConnectionProfile", "Unknown", "ok");
                        break;
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
            }
        }
        private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            await DisplayAlert("Connection", e.NetworkAccess + " " + e.ConnectionProfiles.FirstOrDefault().ToString(), "ok");
        }

        //Battery Info
        private async void BtnGetBatteryInfo_OnClicked(object sender, EventArgs e)
        {

            try
            {
                StringBuilder strBuilder = new StringBuilder();

                strBuilder.AppendLine($"ChargeLevel : {Battery.ChargeLevel}");

                switch (Battery.State)
                {
                    case BatteryState.Charging:
                        strBuilder.AppendLine($"BatteryState : Charging");
                        break;

                    case BatteryState.Discharging:
                        strBuilder.AppendLine($"BatteryState : Discharging");
                        break;

                    case BatteryState.Full:
                        strBuilder.AppendLine($"BatteryState : Full");
                        break;

                    case BatteryState.NotCharging:
                        strBuilder.AppendLine($"BatteryState : NotCharging");
                        break;

                    case BatteryState.NotPresent:
                        strBuilder.AppendLine($"BatteryState : NotPresent");
                        break;

                    case BatteryState.Unknown:
                        strBuilder.AppendLine($"BatteryState : Unknown");
                        break;
                }

                switch (Battery.EnergySaverStatus)
                {
                    case EnergySaverStatus.Unknown:
                        strBuilder.AppendLine($"EnergySaverStatus : Unknown");
                        break;
                    case EnergySaverStatus.On:
                        strBuilder.AppendLine($"EnergySaverStatus : On");
                        break;
                    case EnergySaverStatus.Off:
                        strBuilder.AppendLine($"EnergySaverStatus : Off");
                        break;
                }

                switch (Battery.PowerSource)
                {
                    case BatteryPowerSource.Unknown:
                        strBuilder.AppendLine($"PowerSource : Unknown");
                        break;
                    case BatteryPowerSource.Battery:
                        strBuilder.AppendLine($"PowerSource : Battery");
                        break;
                    case BatteryPowerSource.AC:
                        strBuilder.AppendLine($"PowerSource : AC");
                        break;
                    case BatteryPowerSource.Usb:
                        strBuilder.AppendLine($"PowerSource : Usb");
                        break;
                    case BatteryPowerSource.Wireless:
                        strBuilder.AppendLine($"PowerSource : Wireless");
                        break;
                }

                await DisplayAlert("Battery Info", strBuilder.ToString(), "ok");


            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
            }
        }
        private async void Battery_EnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
        {
            await DisplayAlert("EnergySaverStatusChanged", e.EnergySaverStatus.ToString(), "ok");
        }
        private async void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine($"ChargeLevel : {e.ChargeLevel}");

            switch (e.State)
            {
                case BatteryState.Charging:
                    strBuilder.AppendLine($"BatteryState : Charging");
                    break;

                case BatteryState.Discharging:
                    strBuilder.AppendLine($"BatteryState : Discharging");
                    break;

                case BatteryState.Full:
                    strBuilder.AppendLine($"BatteryState : Full");
                    break;

                case BatteryState.NotCharging:
                    strBuilder.AppendLine($"BatteryState : NotCharging");
                    break;

                case BatteryState.NotPresent:
                    strBuilder.AppendLine($"BatteryState : NotPresent");
                    break;

                case BatteryState.Unknown:
                    strBuilder.AppendLine($"BatteryState : Unknown");
                    break;
            }

            switch (e.PowerSource)
            {
                case BatteryPowerSource.Unknown:
                    strBuilder.AppendLine($"PowerSource : Unknown");
                    break;
                case BatteryPowerSource.Battery:
                    strBuilder.AppendLine($"PowerSource : Battery");
                    break;
                case BatteryPowerSource.AC:
                    strBuilder.AppendLine($"PowerSource : AC");
                    break;
                case BatteryPowerSource.Usb:
                    strBuilder.AppendLine($"PowerSource : Usb");
                    break;
                case BatteryPowerSource.Wireless:
                    strBuilder.AppendLine($"PowerSource : Wireless");
                    break;
            }

            await DisplayAlert("BatteryInfoChanged", strBuilder.ToString(), "ok");

        }

        //Vibration
        private void BtnMakeVibration_OnClicked(object sender, EventArgs e)
        {
            //Need Permission For Vibration

            Vibration.Cancel();


            Vibration.Vibrate(2000);
        }

        //Text To Speech
        private CancellationTokenSource _cancelToken;
        private float _pitchValue;
        private float _volumeValue;
        private async void BtnTextToSpeech_OnClicked(object sender, EventArgs e)
        {
            _cancelToken = new CancellationTokenSource();

            await TextToSpeech.SpeakAsync("How Are You Mohammed Salah , iam Max Bayne ,how are you today", new SpeechOptions()
            {
                Pitch = _pitchValue,
                Volume = _volumeValue
            }, _cancelToken.Token);
        }
        private void BtnStopSpeech_OnClicked(object sender, EventArgs e)
        {
            if (_cancelToken?.IsCancellationRequested ?? true)
                return;

            _cancelToken.Cancel();

        }
        private void SldPitch_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            _pitchValue = (float)e.NewValue;
        }
        private void SldVolume_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            _volumeValue = (float)e.NewValue;
        }

        //Flashlight
        private async void BtnFlashLightON_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOnAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("FlashLight", ex.Message, "ok");
            }
        }
        private async void BtnFlashLightOFF_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOffAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("FlashLight", ex.Message, "ok");
            }
        }
    }
}