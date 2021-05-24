using BarbequeWeather.Client;
using BarbequeWeather.Utilities.Logger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarbequeWeather.Model
{
    public class BarbequeWeatherModel
    {
        private UpcomingWeather UpcomingWeather { get; set; }
        private readonly ILogger _logger;

        public delegate void BbqWeatherDataUpdated(string locationDisclaimer, bool result);

        public event BbqWeatherDataUpdated OnUpdatedWeatherForecast;

        public BarbequeWeatherModel(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void UpdateWeatherForecast(UpcomingWeather newWeatherData)
        {
            _logger.Log($"Starting execution of {nameof(UpdateWeatherForecast)}", Severity.Verbose);
            
            UpcomingWeather = newWeatherData ?? throw new ArgumentNullException(nameof(newWeatherData));

            OnUpdatedWeatherForecast?.Invoke(GetLocationInfo(), IsTimeForBarbeque());

            _logger.Log($"Ending execution of {nameof(UpdateWeatherForecast)}", Severity.Verbose);
        }

        private bool IsTimeForBarbeque()
        {
            var nextFourHours = UpcomingWeather.Hourly.Where(data => DateTimeOffset.FromUnixTimeSeconds(data.UnixDate).UtcDateTime < DateTime.UtcNow.AddHours(4)).ToList();

            LogNextFourHours(nextFourHours);

            if (nextFourHours.All(hourlyData => hourlyData.Temperature >= 20 && (hourlyData.Rain < 2 || hourlyData.Rain is null)))
                return true;

            return false;
        }

        private void LogNextFourHours(List<HourlyForecast> nextFourHours)
        {
            foreach(var hourly in nextFourHours)
            {
                if(hourly.Rain >= 2 || hourly.Temperature < 20)
                    _logger.Log($"BBQ is in danger at {DateTimeOffset.FromUnixTimeSeconds(hourly.UnixDate).DateTime.ToLocalTime()} " +
                        $"- temp will be: {hourly.Temperature}, rain will be {hourly.Rain ?? 0} mm", Severity.Warning);
            }
        }

        private string GetLocationInfo()
        {
            return $"Your location's timezone is: {UpcomingWeather.Timezone}, Longitude: {UpcomingWeather.Lon}, Latitude: {UpcomingWeather.Lat}";
        }
    }
}