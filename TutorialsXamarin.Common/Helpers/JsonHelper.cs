using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Threading.Tasks;


namespace TutorialsXamarin.Common.Helpers
{
    public class JsonHelper
    {        /// <summary>
        /// مسار الملف 
        /// </summary>
        public string FilePath { get; set; }
        public JsonHelper(string filePath)
        {
            FilePath = filePath;
        }

        public async Task<DataTable > ReadTableFromJson()
        {
           
            DataTable dsTopics;
            using (StreamReader r = new StreamReader(FilePath))
            {
                string json =await r.ReadToEndAsync();
              
                 dsTopics = JsonConvert.DeserializeObject<DataTable>(json);
            }

           
            if (dsTopics != null)
            {
                
                return dsTopics;
            }

            return null;

        }
    }
}
