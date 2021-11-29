using System.Net.Http;
using System.Net.Http.Headers;

namespace TutorialsXamarin.Data.Abstract
{
    public abstract class BaseDataService
    {
        #region Http Client

        protected HttpClient HttpClient { get; set; }

        protected string AuthorizationToken { get; set; }

        private void ConfigHttpClient()
        {
            //Config HTTP Client ---------------------------------
            AuthorizationToken = string.Empty;

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            HttpClient = new HttpClient(httpClientHandler);

            HttpClient.DefaultRequestHeaders.Add("accept", "application/json");

            //Authentication Access Token Header

            if (!string.IsNullOrEmpty(AuthorizationToken))
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            }
        }

        #endregion

        protected BaseDataService()
        {
            ConfigHttpClient();
        }
        
    }
}