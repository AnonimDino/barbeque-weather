using System.Threading.Tasks;

namespace BarbequeWeather.Client
{
    public interface IWeatherApiClient<T>
    {
        public Task<T> GetUpcomingWeather(int latitude, int longitude);
    }
}