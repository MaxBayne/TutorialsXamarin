using System;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceSensorsPage
    {
        public DeviceSensorsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                Compass.ReadingChanged += Compass_ReadingChanged;
                if (!Compass.IsMonitoring)
                    Compass.Start(SensorSpeed.UI, true);

                Barometer.ReadingChanged += Barometer_ReadingChanged;
                if (!Barometer.IsMonitoring)
                    Barometer.Start(SensorSpeed.UI);

                Magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
                if (!Magnetometer.IsMonitoring)
                    Magnetometer.Start(SensorSpeed.UI);

                Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                if (!Accelerometer.IsMonitoring)
                    Accelerometer.Start(SensorSpeed.UI);

                OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
                if (!OrientationSensor.IsMonitoring)
                    OrientationSensor.Start(SensorSpeed.UI);

                Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
                if (!Gyroscope.IsMonitoring)
                    Gyroscope.Start(SensorSpeed.UI);

                
            }
            catch (Exception)
            {

         
            }
        }

        

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            try
            {
                Compass.ReadingChanged -= Compass_ReadingChanged;
                if (Compass.IsMonitoring)
                    Compass.Stop();


                Barometer.ReadingChanged -= Barometer_ReadingChanged;
                if (Barometer.IsMonitoring)
                    Barometer.Stop();

                Magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
                if (Magnetometer.IsMonitoring)
                    Magnetometer.Stop();

                Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
                Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();

                OrientationSensor.ReadingChanged -= OrientationSensor_ReadingChanged;
                if (OrientationSensor.IsMonitoring)
                    OrientationSensor.Stop();

                Gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
                if (Gyroscope.IsMonitoring)
                    Gyroscope.Stop();
            }
            catch (Exception)
            {
            }
            
        }

        //البوصلة
        //Compass
        private void StartCompass_OnClicked(object sender, EventArgs e)
        {
            if (!Compass.IsMonitoring)
            {
                Compass.Start(SensorSpeed.UI,true);
            }
            
        }
        private void EndCompass_OnClicked(object sender, EventArgs e)
        {
            if (Compass.IsMonitoring)
            {
                Compass.Stop();

                LblCompass.Text = "Compass";
            }
        }
        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            var compass = e.Reading.HeadingMagneticNorth;

            var closest90 = Math.Round(compass / 90d, MidpointRounding.AwayFromZero) * 90;

            switch (closest90)
            {
                case 360:
                    LblCompass.Text = "Compass = North";
                    break;

                case 90:
                    LblCompass.Text = "Compass = East";
                    break;

                case 180:
                    LblCompass.Text = "Compass = South";
                    break;

                case 270:
                    LblCompass.Text = "Compass = West";
                    break;

            }
        }

        //الضغط الجوي
        //Barometer
        private void StartBarometer_OnClicked(object sender, EventArgs e)
        {
            if (!Barometer.IsMonitoring)
            {
                Barometer.Start(SensorSpeed.UI);
            }

        }
        private void EndBarometer_OnClicked(object sender, EventArgs e)
        {
            if (Barometer.IsMonitoring)
            {
                Barometer.Stop();

                LblBarometer.Text = "Barometer";
            }
        }
        private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            LblBarometer.Text =  "Barometer = " + e.Reading.ToString();
        }

        //المجال المغناطيسي
        //Magnetometer
        private void StartMagnetometer_OnClicked(object sender, EventArgs e)
        {
            if (!Magnetometer.IsMonitoring)
            {
                Magnetometer.Start(SensorSpeed.UI);
            }

        }
        private void EndMagnetometer_OnClicked(object sender, EventArgs e)
        {
            if (Magnetometer.IsMonitoring)
            {
                Magnetometer.Stop();

                LblMagnetometer.Text = "Magnetometer";
            }
        }
        private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            LblMagnetometer.Text = "Magnetometer = " + e.Reading.ToString();
        }

        //التسارع
        //Accelerometer
        private void StartAccelerometer_OnClicked(object sender, EventArgs e)
        {
            if (!Accelerometer.IsMonitoring)
            {
                Accelerometer.Start(SensorSpeed.UI);
            }

        }
        private void EndAccelerometer_OnClicked(object sender, EventArgs e)
        {
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.Stop();

                LblAccelerometer.Text = "Accelerometer";
            }
        }
        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            LblAccelerometer.Text = "Accelerometer = " + e.Reading.ToString();
        }
        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            LblAccelerometer.Text += " - ShakeDetected";
        }

        //الدوران
        //Gyroscope
        private void StartGyroscope_OnClicked(object sender, EventArgs e)
        {
            if (!Gyroscope.IsMonitoring)
            {
                Gyroscope.Start(SensorSpeed.UI);
            }

        }
        private void EndGyroscope_OnClicked(object sender, EventArgs e)
        {
            if (Gyroscope.IsMonitoring)
            {
                Gyroscope.Stop();

                LblGyroscope.Text = "Gyroscope";
            }
        }
        private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            LblGyroscope.Text = "Gyroscope = " + e.Reading.ToString();
        }

        //الإلتفاف
        //OrientationSensor
        private void StartOrientationSensor_OnClicked(object sender, EventArgs e)
        {
            if (!OrientationSensor.IsMonitoring)
            {
                OrientationSensor.Start(SensorSpeed.UI);
            }

        }
        private void EndOrientationSensor_OnClicked(object sender, EventArgs e)
        {
            if (OrientationSensor.IsMonitoring)
            {
                OrientationSensor.Stop();

                LblOrientation.Text = "Orientation";
            }
        }
        private void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            LblOrientation.Text = "Orientation = " + e.Reading.ToString();
        }

    }
}