using BarbequeWeather.Client;
using BarbequeWeather.Controller;
using BarbequeWeather.Model;
using BarbequeWeather.Utilities.Logger;
using BarbequeWeather.View;
using System.Net.Http;
using System.Threading.Tasks;

namespace BarbequeWeather
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var logger = new ConsoleLogger();
            var consoleView = new ConsoleView();
            var model = new BarbequeWeatherModel(logger);

            var httpClient = new HttpClient();
            var weatherApiClient = new OpenWeatherApiClient(httpClient, logger);

            BarbequeWeatherController controller = new BarbequeWeatherController(consoleView, model, weatherApiClient, logger);
            await controller.ExecuteBarbequeCheck();
        }
    }
}
