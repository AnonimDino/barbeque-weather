using BarbequeWeather.Client;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BarbequeWeather.Test
{
    class OpenWeatherApiClientTests
    {
        private TestLogger _logger;
        private Mock<HttpClient> _httpClientMock;

        [SetUp]
        public void Setup()
        {
            _logger = new TestLogger();
            _httpClientMock = new Mock<HttpClient>();
        }

        [Test]
        public void OpenWeatherApiClient_OnNullLogger_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OpenWeatherApiClient(_httpClientMock.Object, null));
        }

        [Test]
        public void OpenWeatherApiClient_OnNullHttpClient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OpenWeatherApiClient(null, _logger));
        }
    }
}
