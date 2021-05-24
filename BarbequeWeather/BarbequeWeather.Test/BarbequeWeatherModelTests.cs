using BarbequeWeather.Client;
using BarbequeWeather.Model;
using BarbequeWeather.Utilities.Logger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbequeWeather.Test
{
    class BarbequeWeatherModelTests : TestBase
    {
        private TestLogger _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new TestLogger();
        }

        [Test]
        public void BarbequeWeatherModel_OnNullLogger_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BarbequeWeatherModel(null));
        }

        [Test]
        public void BarbequeWeatherModel_UpdateWeatherForecast_ThrowsArgumentNullException()
        {
            var testModel = new BarbequeWeatherModel(_logger);
            Assert.Throws<ArgumentNullException>(() => testModel.UpdateWeatherForecast(null));
        }

        [Test]
        public void BarbequeWeatherModel_UpdateWeatherForecast_Fires_OnUpdatedWeatherForecast()
        {
            var testModel = new BarbequeWeatherModel(_logger);
            testModel.OnUpdatedWeatherForecast += TestObserverMethod;

            testModel.UpdateWeatherForecast(CreateUpcomingWeatherForecast());

            _logger.AssertLogged($"Your location's timezone is: Europe/Budapest, Longitude: {TEST_LONGITUDE}, Latitude: {TEST_LATITUDE}", Severity.Verbose);
        }

        private UpcomingWeather CreateUpcomingWeatherForecast()
        {
            var upcomingWeather = new UpcomingWeather
            {
                Lat = TEST_LATITUDE,
                Lon = TEST_LONGITUDE,
                Timezone = "Europe/Budapest",
                Hourly = GetHourlyForeCastList()
            };

            return upcomingWeather;
        }

        private List<HourlyForecast> GetHourlyForeCastList()
        {
            return new List<HourlyForecast> { {
                    new HourlyForecast { Rain = 0.5, Temperature = 21.3, UnixDate = 1621866486 }
                }};
        }

        private void TestObserverMethod(string message, bool result)
        {
            _logger.Log(message, Severity.Verbose);
        }
    }
}
