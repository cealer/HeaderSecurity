using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SecurityHeaders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastServices weatherForecastServices)
        {
            _logger = logger;
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            int count = 5;
            return _weatherForecastServices.GetWeatherForecasts(count);
        }
    }
}
