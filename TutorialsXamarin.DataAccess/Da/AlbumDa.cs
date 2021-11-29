using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TutorialsXamarin.DataAccess.Models;
using Newtonsoft.Json;
using TutorialsXamarin.Common.Enums;
using TutorialsXamarin.DataAccess.Abstracts;

namespace TutorialsXamarin.DataAccess.Da
{
    public class AlbumDa: DataAccessBase
    {
        public AlbumDa(ConnectionType connectionType) : base(connectionType) {}

        #region Reterive

        public async Task<List<AlbumPhoto>> Get_All_Photos_Async()
        {
            //GET: Web Api REST Service 

            HttpClient webClient = new HttpClient();

            var response = await webClient.GetStringAsync("http://jsonplaceholder.typicode.com/photos");

            //Convert Json String to Object (IEnumerable<AlbumPhoto>)
            return JsonConvert.DeserializeObject<List<AlbumPhoto>>(response);
            
        }

        #endregion

        #region Insert

        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
        
    }
}
