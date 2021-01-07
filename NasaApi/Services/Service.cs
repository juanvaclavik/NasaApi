using NasaApi.Services.ServiceResult;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NasaApi.Services
{
    public class Service : IService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Service(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<ServiceResult<T>> GetData<T>(string url)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var result = new ServiceResult<T>();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result.Data = JsonConvert.DeserializeObject<T>(jsonResponse);
                }
                
                return result;
            }
            catch (Exception e)
            {
                result.AddViolation(e);
                
                return result;
            }
        }
    }
}
