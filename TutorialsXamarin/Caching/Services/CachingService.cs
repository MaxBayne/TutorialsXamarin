using Akavache;
using TutorialsXamarin.Caching.Interfaces;

namespace TutorialsXamarin.Caching.Services
{
    public class CachingService:ICacheService
    {
        /// <summary>
        /// Start Caching Service Power By AKAVACHE
        /// </summary>
        public static void ConfigCaching(string appName= "TutorialsXamarin")
        {
            Registrations.Start(appName);
        }


        public IBlobCache LocalCache { get; set; }
        public IBlobCache UserCache { get; set; }
        public IBlobCache SecureCache { get; set; }
        public IBlobCache MemoryCache { get; set; }

        public CachingService()
        {
            LocalCache = BlobCache.LocalMachine;
            UserCache = BlobCache.UserAccount;
            MemoryCache = BlobCache.InMemory;
            SecureCache = BlobCache.Secure;
            
        }
    }
}