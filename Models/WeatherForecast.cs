using System.Collections.Generic;
using System.Linq;

namespace WeatherServiceAPI.Models
{
    public class WeatherForecast
    {
        public List<CurrentWeather> Forecast { get; set; }

        public WeatherForecast(List[] list)
        {
            Forecast = CastToCurrentWeatherList(list);
        }

        private List<CurrentWeather> CastToCurrentWeatherList(List[] list)
        {
            var newList = list.Select(w =>
            {
                return new CurrentWeather(w.main.temp, w.wind.speed, w.clouds.all, w.dt_txt);
            }).ToList();

            return newList;
        }
    }
}
