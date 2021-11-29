using Akavache;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using TutorialsXamarin.Caching.Enums;

namespace TutorialsXamarin.Caching.Extensions
{
    public static class CacheExtensions
    {
        #region Check

        /// <summary>
        /// Check if Key Exist then Return True or False if not exist
        /// </summary>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<bool> IsExistAsync(this IBlobCache blobCache, string key)
        {
            try
            {
                await blobCache.Get(key);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if Key Exist then Return True or False if not exist
        /// </summary>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<bool> IsExistAsync(this IBlobCache blobCache, CacheKeys key)
        {
            try
            {
                await blobCache.Get(key.ToString());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Read

        /// <summary>
        /// Read Key Value From Cache if exist or null if not exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<T> ReadAsync<T>(this IBlobCache blobCache, string key)
        {
            var result = default(T);

            try
            {
                result = await blobCache.GetObject<T>(key);

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        /// <summary>
        /// Read Key Value From Cache if exist or null if not exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<T> ReadAsync<T>(this IBlobCache blobCache, CacheKeys key)
        {
            var result = default(T);

            try
            {
                result = await blobCache.GetObject<T>(key.ToString());

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }



        /// <summary>
        /// Read Key Value From Cache if exist or Fetch Data and Store it and then Return cached data , the default cached time as 60 second
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="fetch"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task<T> ReadOrFetchAsync<T>(this IBlobCache blobCache, string key, Func<T> fetch = null, TimeSpan expireTime = default)
        {
            var result = default(T);

            try
            {

                //Check if key exist
                if (await blobCache.IsExistAsync(key))
                {
                    //Key Exist then Read its data
                    return await blobCache.ReadAsync<T>(key);
                }

                //Key Not Exist then Fetch Data and store it and return Cached Data
                if (fetch != null)
                {
                    if (expireTime == default)
                        expireTime = TimeSpan.FromSeconds(60);


                    return await blobCache.WriteAndGetAsync(key, fetch, expireTime);
                }

                return result;

            }
            catch (Exception)
            {
                return result;
            }
        }

        /// <summary>
        /// Read Key Value From Cache if exist or Fetch Data and Store it and then Return cached data , the default cached time as 60 second
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="fetch"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task<T> ReadOrFetchAsync<T>(this IBlobCache blobCache, CacheKeys key, Func<T> fetch=null, TimeSpan expireTime = default)
        {
            var result = default(T);

            try
            {

                //Check if key exist
                if (await blobCache.IsExistAsync(key))
                {
                    //Key Exist then Read its data
                    return await blobCache.ReadAsync<T>(key);
                }

                //Key Not Exist then Fetch Data and store it and return Cached Data
                if (fetch != null)
                {
                    if (expireTime == default)
                        expireTime = TimeSpan.FromSeconds(60);


                    return await blobCache.WriteAndGetAsync(key, fetch, expireTime);
                }

                return result;

            }
            catch (Exception)
            {
                return result;
            }
        }

        /// <summary>
        /// Read Key Value From Cache if exist or Fetch Data and Store it and then Return cached data , the default cached time as 60 second
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="fetch"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task<T> ReadOrFetchAsync<T>(this IBlobCache blobCache, CacheKeys key, Func<Task<T>> fetch = null, TimeSpan expireTime = default)
        {
            var result = default(T);

            try
            {

                //Check if key exist
                if (await blobCache.IsExistAsync(key))
                {
                    //Key Exist then Read its data
                    return await blobCache.ReadAsync<T>(key);
                }

                //Key Not Exist then Fetch Data and store it and return Cached Data
                if (fetch != null)
                {
                    if (expireTime == default)
                        expireTime = TimeSpan.FromSeconds(60);

                    var data = await fetch.Invoke();

                    return await blobCache.WriteAndGetAsync(key, data, expireTime);
                }

                return result;

            }
            catch (Exception)
            {
                return result;
            }
        }

        /// <summary>
        /// Read Key Value From Cache if exist or Fetch Data and Store it and then Return cached data , the default cached time as 60 second
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="fetch"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task<T> ReadOrFetchAsync<T>(this IBlobCache blobCache, string key, Func<Task<T>> fetch = null, TimeSpan expireTime = default)
        {
            var result = default(T);

            try
            {

                //Check if key exist
                if (await blobCache.IsExistAsync(key))
                {
                    //Key Exist then Read its data
                    return await blobCache.ReadAsync<T>(key);
                }

                //Key Not Exist then Fetch Data and store it and return Cached Data
                if (fetch != null)
                {
                    if (expireTime == default)
                        expireTime = TimeSpan.FromSeconds(60);

                    var data = await fetch.Invoke();

                    return await blobCache.WriteAndGetAsync(key, data, expireTime);
                }

                return result;

            }
            catch (Exception)
            {
                return result;
            }
        }
        #endregion

        #region Write

        /// <summary>
        /// Write Key Value inside Cache if not exist , or update it if exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task WriteAsync<T>(this IBlobCache blobCache, string key, T data, TimeSpan expireTime)
        {
            try
            {
                await blobCache.InsertObject(key, data, expireTime);
            }
            catch (Exception)
            {
                //Ignore
            }
        }

        /// <summary>
        /// Write Key Value inside Cache if not exist , or update it if exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task WriteAsync<T>(this IBlobCache blobCache, CacheKeys key, T data, TimeSpan expireTime)
        {
            try
            {
                await blobCache.InsertObject(key.ToString(), data, expireTime);
            }
            catch (Exception)
            {
                //Ignore
            }
        }



        /// <summary>
        /// Write Key Value inside Cache if not exist , or update it if exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task WriteAsync<T>(this IBlobCache blobCache, string key, Func<T> data, TimeSpan expireTime)
        {
            try
            {
                var result = data.Invoke();
                await blobCache.InsertObject(key, result, expireTime);
            }
            catch (Exception)
            {
                //Ignore
            }
        }
        /// <summary>
        /// Write Key Value inside Cache if not exist , or update it if exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task WriteAsync<T>(this IBlobCache blobCache, CacheKeys key, Func<T> data, TimeSpan expireTime)
        {
            try
            {
                var result = data.Invoke();
                await blobCache.InsertObject(key.ToString(), result, expireTime);
            }
            catch (Exception)
            {
                //Ignore
            }
        }



        /// <summary>
        /// Write Key Value inside Cache if not exist , or update it if exist , and return the cached data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task<T> WriteAndGetAsync<T>(this IBlobCache blobCache, string key, T data, TimeSpan expireTime)
        {

            await blobCache.InsertObject(key, data, expireTime);

            return await blobCache.ReadAsync<T>(key);

        }

        /// <summary>
        /// Write Key Value inside Cache if not exist , or update it if exist , and return the cached data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task<T> WriteAndGetAsync<T>(this IBlobCache blobCache, CacheKeys key, T data, TimeSpan expireTime)
        {

            await blobCache.InsertObject(key.ToString(), data, expireTime);

            return await blobCache.ReadAsync<T>(key);

        }

        /// <summary>
        /// Write Key Value inside Cache if not exist , or update it if exist , and return the cached data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task<T> WriteAndGetAsync<T>(this IBlobCache blobCache, CacheKeys key, Func<T> data, TimeSpan expireTime)
        {
            var result = data.Invoke();

            await blobCache.InsertObject(key.ToString(), result, expireTime);

            return await blobCache.ReadAsync<T>(key);
            
        }

        /// <summary>
        /// Write Key Value inside Cache if not exist , or update it if exist , and return the cached data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public static async Task<T> WriteAndGetAsync<T>(this IBlobCache blobCache, string key, Func<T> data, TimeSpan expireTime)
        {
            var result = data.Invoke();

            await blobCache.InsertObject(key, result, expireTime);

            return await blobCache.ReadAsync<T>(key);

        }

        #endregion

        #region Clean

        /// <summary>
        /// Remove Key From Cache if exist
        /// </summary>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task RemoveAsync(this IBlobCache blobCache, string key)
        {
            try
            {
                await blobCache.Invalidate(key);
            }
            catch (Exception)
            {
                //Ignored
            }
        }

        /// <summary>
        /// Remove Key From Cache if exist
        /// </summary>
        /// <param name="blobCache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task RemoveAsync(this IBlobCache blobCache, CacheKeys key)
        {
            try
            {
                await blobCache.Invalidate(key.ToString());
            }
            catch (Exception)
            {
                //Ignored
            }
        }

        /// <summary>
        /// Remove All Keys From Cache
        /// </summary>
        /// <param name="blobCache"></param>
        /// <returns></returns>
        public static async Task RemoveAllAsync(this IBlobCache blobCache)
        {
            try
            {
                await blobCache.InvalidateAll();
            }
            catch (Exception)
            {
                //Ignored
            }
        }

        #endregion

        

    }
}