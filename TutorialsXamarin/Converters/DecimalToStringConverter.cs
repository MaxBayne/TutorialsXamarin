using System;
using System.Globalization;
using Xamarin.Forms;

namespace TutorialsXamarin.Converters
{
    public class DecimalToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Convert Value From Source To Target
            return value + " EGP ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Convert Value From Target To Source
            return value.ToString().Replace(" EGP ", string.Empty);
        }
    }
}
