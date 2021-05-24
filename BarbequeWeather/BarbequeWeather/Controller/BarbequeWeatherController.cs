using BarbequeWeather.View;
using BarbequeWeather.Model;
using BarbequeWeather.Client;
using System.Threading.Tasks;
using BarbequeWeather.Utilities.Logger;
using System;

namespace BarbequeWeather.Controller
{
    public class BarbequeWeatherController
    {
        private readonly IView _view;
        private readonly BarbequeWeatherModel _model;
        private readonly IWeatherApiClient<UpcomingWeather> _weatherApiClient;
        private readonly ILogger _logger;

        public BarbequeWeatherController(IView view, BarbequeWeatherModel model, IWeatherApiClient<UpcomingWeather> weatherApiClient, ILogger logger)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _weatherApiClient = weatherApiClient ?? throw new ArgumentNullException(nameof(weatherApiClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _model.OnUpdatedWeatherForecast += _view.DisplayResult;
        }

        public async Task ExecuteBarbequeCheck()
        {
            _logger.Log($"Starting execution of {nameof(ExecuteBarbequeCheck)}", Severity.Verbose);
            var runAgain = true;
            while (runAgain)
            {
                int latitude = _view.GetLatitude();
                int longitude = _view.GetLongitude();
                var forecast = await _weatherApiClient.GetUpcomingWeather(latitude, longitude);

                if (forecast != null)
                    _model.UpdateWeatherForecast(forecast);
                else
                {
                    _view.DisplayError("Could not retrieve forecast from API.");
                    _logger.Log("Could not retrieve forecast from API.", Severity.Warning);
                }

                runAgain = _view.RunAgain();
            }
            _logger.Log($"Ending execution of {nameof(ExecuteBarbequeCheck)}", Severity.Verbose);
        }
    }
}
