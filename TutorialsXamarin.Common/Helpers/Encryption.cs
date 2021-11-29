using System.Security.Cryptography;
using System.Text;

namespace TutorialsXamarin.Common.Helpers
{
    public class Encryption
    {
        public static string EncodeMd5(string pureText)
        {
            // Use input string to calculate MD5 hash

            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(pureText.ToLower());
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (var t in hashBytes)
                {
                    sb.Append(t.ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
    }
}
