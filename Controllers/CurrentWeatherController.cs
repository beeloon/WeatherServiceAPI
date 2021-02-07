using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherServiceAPI.Models;

namespace WeatherInfoService.Controllers
{
    [ApiController]
    [Route("/api/GetCurrentWeather")]
    public class CurrentWeatherController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public CurrentWeatherController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("{city}")]
        public async Task<CurrentWeather> Get(string city)
        {
            var client = _clientFactory.CreateClient("weather");
            var url = $"?appid={API.KEY}&units=metric&q={city}";
            var response = await client.GetFromJsonAsync<OpenWeatherModel>(url);

            var (temperature, wind, clouds) = (
                response.main.temp,
                response.wind.speed,
                response.clouds.all
            );

            var weather = new CurrentWeather(temperature, wind, clouds, null);

            return weather;
        }
    }
}
