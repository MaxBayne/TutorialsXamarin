using System;

namespace TutorialsXamarin.Common.Helpers
{
    public static class CheckValue
    {

        public static decimal check_Decimal_Value(decimal? value)
        {
            try
            {
                if (value != null)
                {
                    return (decimal)value;
                }

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        //Tested
        public static int check_Integer_Value(int? value)
        {
            try
            {
                if (value != null)
                {
                    return (int)value;
                }

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        //Tested
        public static bool check_Boolean_Value(bool? value)
        {
            try
            {
                if (value != null)
                {
                    return (bool)value;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
