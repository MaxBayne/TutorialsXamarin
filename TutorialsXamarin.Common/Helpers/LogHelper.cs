using System;
using System.IO;
using System.Reflection;

namespace TutorialsXamarin.Common.Helpers
{
    public static class LogHelper
    {
        private static string _mExePath = string.Empty;


        public static void LogWrite(string logMessage)
        {
            _mExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(_mExePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\n");
                //txtWriter.WriteLine("({0} {1})", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("({0}) => {1}", DateTime.Now,logMessage);
                //txtWriter.WriteLine("  => {0}", logMessage);
                //txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
