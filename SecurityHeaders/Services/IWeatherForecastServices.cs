using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityHeaders
{
    public interface IWeatherForecastServices
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts(int count);
    }
}
