using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherServiceAPI.Models;


namespace WeatherInfoService.Controllers
{
    [ApiController]
    [Route("/api/GetWeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public WeatherForecastController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("{city}")]
        public async Task<WeatherForecast> Get(string city)
        {
            var client = _clientFactory.CreateClient("forecast");
            var url = $"?appid={API.KEY}&units=metric&q={city}";
            var response = await client.GetFromJsonAsync<OpenWeatherForecastModel>(url);

            var forecast = new WeatherForecast(response.list);

            return forecast;
        }
    }
}
