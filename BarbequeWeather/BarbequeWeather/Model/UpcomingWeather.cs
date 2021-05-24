using BarbequeWeather.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BarbequeWeather.Client
{
    public class UpcomingWeather
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Timezone { get; set; }

        public List<HourlyForecast> Hourly { get; set; }
    }

    [JsonConverter(typeof(JsonPathConverter))]
    public class HourlyForecast
    {
        [JsonProperty("dt")]
        public long UnixDate { get; set; }

        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("rain.1h")]
        public double? Rain { get; set; }
    }
}