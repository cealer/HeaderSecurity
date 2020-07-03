using SecurityHeaders;
using System.Collections.Specialized;
using System.Linq;
using Xunit;

namespace UnitTest
{
    public class WeatherForecastTests
    {
        [Fact]
        public void SecurityHeaders_GetWeatherForecast_ReturnList_Success()
        {
            //Arrange
            int count = 5;
            WeatherForecastServices weatherForecast = new WeatherForecastServices();
            //Act
           var result= weatherForecast.GetWeatherForecasts(count);
            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(count,result.Count());
        }
    }
}
