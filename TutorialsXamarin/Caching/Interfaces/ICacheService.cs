using Akavache;

namespace TutorialsXamarin.Caching.Interfaces
{
    public interface ICacheService
    {
        /// <summary>
        /// Store Data that Not Related To User , So Will not be synced to Cloud for Other Devices
        /// </summary>
        IBlobCache LocalCache { get; set; }

        /// <summary>
        /// Store Data that Related To User , So can be synced to Cloud for Other Devices
        /// </summary>
        IBlobCache UserCache { get; set; }

        /// <summary>
        /// Store Secure Data Only like Credentials , passwords etc
        /// </summary>
        IBlobCache SecureCache { get; set; }

        /// <summary>
        /// Store Data Inside Memory , will be removed when application restart
        /// </summary>
        IBlobCache MemoryCache { get; set; }

    }
}