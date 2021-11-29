using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;
using Akavache;
using TutorialsXamarin.Business.Models;
using TutorialsXamarin.Caching.Enums;
using TutorialsXamarin.Caching.Interfaces;
using TutorialsXamarin.Data.Abstract;
using TutorialsXamarin.Data.Interfaces;
using TutorialsXamarin.Caching.Extensions;

namespace TutorialsXamarin.Data.Services
{
    public class CustomersService:BaseDataService,ICustomersService
    {
        private readonly ICacheService _cacheService;
        public CustomersService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        #region Retreive

        public async Task<Customer> GetCustomerByCodeAsync(Guid customerCode)
        {
            try
            {
                var serviceUri = $"{App.ApiUrl}/customers/{customerCode}";

                //Call Service End Point
                var response = await HttpClient.GetAsync(serviceUri);

                //Check Response Status
                if (response.IsSuccessStatusCode)
                {
                    //If Success Response then Retrieve the Response Content
                    var content = await response.Content.ReadAsStringAsync();

                    //Convert Json Content to Object
                    return JsonConvert.DeserializeObject<Customer>(content);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var serviceUri = $"{App.ApiUrl}/customers/{customerId}";

                //Call Service End Point
                var response = await HttpClient.GetAsync(serviceUri);

                //Check Response Status
                if (response.IsSuccessStatusCode)
                {
                    //If Success Response then Retrieve the Response Content
                    var content = await response.Content.ReadAsStringAsync();

                    //Convert Json Content to Object
                    return JsonConvert.DeserializeObject<Customer>(content);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ObservableCollection<Customer>> GetCustomersAsync()
        {
            try
            {
                var serviceUri = $"{App.ApiUrl}/customers";

                //Call Service End Point
                var response = await HttpClient.GetAsync(serviceUri);

                //Check Response Status
                if (response.IsSuccessStatusCode)
                {
                    //If Success Response then Retrieve the Response Content
                    var content = await response.Content.ReadAsStringAsync();

                    //Convert Json Content to Object
                    return JsonConvert.DeserializeObject<ObservableCollection<Customer>>(content);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Customer>> GetCustomersToListAsync()
        {
            try
            {
                
                //var list = await BlobCache.LocalMachine.GetOrFetchObject<List<Customer>>("CustomersList", async () =>
                //{
                //    var serviceUri = $"{App.ApiUrl}/customers";

                //    //Define the Polly Policy that handel any httpRequestException or StatusCode Not Success then wait and retry 5 times
                //    var response = await Policy.HandleResult<HttpResponseMessage>(x => !x.IsSuccessStatusCode)
                //        .Or<HttpRequestException>()
                //        .WaitAndRetryAsync(retryCount: 5, sleepDurationProvider: counter => TimeSpan.FromSeconds(Math.Pow(2, counter)))
                //        .ExecuteAsync(async () => await HttpClient.GetAsync(serviceUri));


                //    //Check Response Status
                //    if (response.IsSuccessStatusCode)
                //    {
                //        //If Success Response then Retrieve the Response Content
                //        var content = await response.Content.ReadAsStringAsync();

                //        //Convert Json Content to Object
                //        return JsonConvert.DeserializeObject<List<Customer>>(content);
                //    }

                //    return null;
                //});

                //return list;



                var result = await _cacheService.LocalCache.ReadOrFetchAsync<List<Customer>>(CacheKeys.CustomersList, async() =>
                {
                        var serviceUri = $"{App.ApiUrl}/customers";

                        //Define the Polly Policy that handel any httpRequestException or StatusCode Not Success then wait and retry 5 times
                        //var response = await Policy.HandleResult<HttpResponseMessage>(x => !x.IsSuccessStatusCode)
                        //    .Or<HttpRequestException>()
                        //    .WaitAndRetryAsync(retryCount: 5, sleepDurationProvider: counter => TimeSpan.FromSeconds(Math.Pow(2, counter)))
                        //    .ExecuteAsync(async () => await HttpClient.GetAsync(serviceUri));
                        
                        var response = await HttpClient.GetAsync(serviceUri);
                        //If Success Response then Retrieve the Response Content
                        var content = await response.Content.ReadAsStringAsync();

                        //Convert Json Content to Object
                        return JsonConvert.DeserializeObject<List<Customer>>(content);

                });

                return result;

              
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Insert

        public async Task<Customer> AddCustomer(Customer newCustomer)
        {
            try
            {
                var serviceUri = $"{App.ApiUrl}/customers";

                //Convert Object To Json by Serialization
                var json = JsonConvert.SerializeObject(newCustomer);

                //Format Json as HTTP Content String
                var httpContent = new StringContent(json,System.Text.Encoding.UTF8,"application/json");

                //Call Service End Point
                var response = await HttpClient.PostAsync(serviceUri, httpContent);

                //Check Response Status
                if (response.IsSuccessStatusCode)
                {
                    //If Success Response then Retrieve the Response Content
                    var content = await response.Content.ReadAsStringAsync();

                    //Convert Json Content to Object
                    return JsonConvert.DeserializeObject<Customer>(content);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Update

        public async Task<Customer> UpdateCustomer(Customer updatedCustomer)
        {
            try
            {
                var serviceUri = $"{App.ApiUrl}/customers";

                //Convert Object To Json by Serialization
                var json = JsonConvert.SerializeObject(updatedCustomer);

                //Format Json as HTTP Content String
                var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                //Call Service End Point
                var response = await HttpClient.PutAsync(serviceUri, httpContent);

                //Check Response Status
                if (response.IsSuccessStatusCode)
                {
                    //If Success Response then Retrieve the Response Content
                    var content = await response.Content.ReadAsStringAsync();

                    //Convert Json Content to Object
                    return JsonConvert.DeserializeObject<Customer>(content);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Delete

        public async Task<bool> DeleteCustomer(int id)
        {
            try
            {
                var serviceUri = $"{App.ApiUrl}/customers/{id}";

                //Call Service End Point
                var response = await HttpClient.DeleteAsync(serviceUri);

                //Check Response Status
                if (response.IsSuccessStatusCode)
                {
                    //If Success Response then Retrieve the Response Content
                     await response.Content.ReadAsStringAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCustomer(Guid code)
        {
            try
            {
                var serviceUri = $"{App.ApiUrl}/customers/{code}";

                //Call Service End Point
                var response = await HttpClient.DeleteAsync(serviceUri);

                //Check Response Status
                if (response.IsSuccessStatusCode)
                {
                    //If Success Response then Retrieve the Response Content
                    await response.Content.ReadAsStringAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}