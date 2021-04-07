using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Viajes365RestApi.Dtos;
using Viajes365RestApi.Helpers;

namespace Viajes365RestApi.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetByCityId(long id);
    }

    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private string apikey = "&apid=";

        public WeatherService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _configuration = configuration;
            client = clientFactory.CreateClient("TuTiempoNetApi");
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            apikey += appSettings.TuTiempoApiKey;
            client.Timeout = new System.TimeSpan(0,0,10);
        }

        public async Task<WeatherDto> GetByCityId(long id)
        {
            var url = string.Format("/json/?lan=es&lid={0}", id);
            url += apikey;
            var result = new WeatherDto();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<WeatherDto>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
