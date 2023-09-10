using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ObiletJourney.Business.Interfaces;
using ObiletJourney.Core.Entities.API;
using System.Net.Http.Headers;
using System.Text;

namespace ObiletJourney.Business.Services
{
    public class ObiletAPIService : IObiletAPIService
    {
        private readonly string _apiClientToken;
        private readonly string _apiEndPoint;

        public ObiletAPIService(IOptions<APISetting> apiSetting)
        {
            _apiClientToken = apiSetting.Value.ApiClientToken;
            _apiEndPoint = apiSetting.Value.ApiEndPoint;
        }

        public async Task<string> PostAsync<T>(string Uri, T data)
        {
            using (HttpClient httpClient = new())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + _apiClientToken);

                StringContent requestContent = new(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(_apiEndPoint + Uri, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    return responseJson;
                }
                else
                {
                    throw new HttpRequestException("İstek sırasında bir hata oluştu!");
                }
            }
        }
    }
}
