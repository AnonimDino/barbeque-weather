using BarbequeWeather.Utilities.Logger;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BarbequeWeather.Client
{
    public class OpenWeatherApiClient : IWeatherApiClient<UpcomingWeather>
    {
        private const string API_KEY = "ea305d9a9362485b8bf56c11c1707694";
        private const string EXCLUDE = "current,minutely,daily,alerts";
        private const string UNITS = "metric";
        private const string BASE_URL = "https://api.openweathermap.org/data/2.5/onecall";

        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public OpenWeatherApiClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<UpcomingWeather> GetUpcomingWeather(int latitude, int longitude)
        {
            try
            {
                _logger.Log("Sending request to OpenWeatherAPI..", Severity.Verbose);
                var uri = new Uri($"{BASE_URL}?lat={latitude}&lon={longitude}&exclude={EXCLUDE}&appid={API_KEY}&units={UNITS}");
                var responseBody = await _httpClient.GetStringAsync(uri);
                _logger.Log("Successful request to OpenWeatherAPI..", Severity.Verbose);
                return JsonConvert.DeserializeObject<UpcomingWeather>(responseBody);
            }
            catch (Exception ex)
            {
                _logger.Log($"Exception in {nameof(GetUpcomingWeather)}, message: {ex.Message}, trace: {ex.StackTrace}", Severity.Error);
                return null;
            }
        }
    }
}
