using BarbequeWeather.Client;
using BarbequeWeather.Controller;
using BarbequeWeather.Model;
using BarbequeWeather.Utilities.Logger;
using BarbequeWeather.View;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace BarbequeWeather.Test
{
    public class BarbequeWeatherControllerTests : TestBase
    {
        private Mock<IView> _viewMock;
        private Mock<BarbequeWeatherModel> _model;
        private Mock<IWeatherApiClient<UpcomingWeather>> _weatherApiClientMock;
        private TestLogger _logger;


        [SetUp]
        public void Setup()
        {
            _logger = new TestLogger();
            _viewMock = new Mock<IView>();
            _weatherApiClientMock = new Mock<IWeatherApiClient<UpcomingWeather>>();
            _model = new Mock<BarbequeWeatherModel>(_logger);

        }

        [Test]
        public void BarbequeWeatherController_OnNullView_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BarbequeWeatherController(null, _model.Object, _weatherApiClientMock.Object, _logger));
        }

        [Test]
        public void BarbequeWeatherController_OnNullModel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BarbequeWeatherController(_viewMock.Object, null, _weatherApiClientMock.Object, _logger));
        }

        [Test]
        public void BarbequeWeatherController_OnNullApiClient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BarbequeWeatherController(_viewMock.Object, _model.Object, null, _logger));
        }

        [Test]
        public void BarbequeWeatherController_OnNullLogger_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BarbequeWeatherController(_viewMock.Object, _model.Object, _weatherApiClientMock.Object, null));
        }

        [Test]
        public async Task BarbequeWeatherController_ExecuteBarbequeCheck_WeatherForecastIsNull()
        {
            _viewMock.Setup(v => v.GetLatitude()).Returns(TEST_LATITUDE);
            _viewMock.Setup(v => v.GetLongitude()).Returns(TEST_LONGITUDE);
            _weatherApiClientMock.Setup(c => c.GetUpcomingWeather(TEST_LATITUDE, TEST_LONGITUDE)).ReturnsAsync(default(UpcomingWeather));
            var controller = new BarbequeWeatherController(_viewMock.Object, _model.Object, _weatherApiClientMock.Object, _logger);
            await controller.ExecuteBarbequeCheck();

            _viewMock.VerifyAll();
            _weatherApiClientMock.VerifyAll();
            _logger.AssertLogged("Could not retrieve forecast from API.", Severity.Warning);
        }
    }
}