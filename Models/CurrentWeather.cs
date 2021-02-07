using System;

namespace WeatherServiceAPI.Models
{
    public class CurrentWeather
    {
        public string Date { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Cloud { get; set; }

        public CurrentWeather(float temperature, float wind, int cloud, string dt)
        {
            Cloud = cloud.ToString() + " %";
            Wind = ((int)wind).ToString() + " m/s";
            Temperature = ((int)temperature).ToString() + "°C";
            Date = dt ?? DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
