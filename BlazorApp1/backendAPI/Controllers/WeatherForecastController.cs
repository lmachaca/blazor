using Microsoft.AspNetCore.Mvc;

namespace backendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("hello")]
        public string GetHello()
        {
            return "Hello from the API!";
        }

        [HttpGet("time")]
        public string GetTime()
        {
            return $"Server time: {DateTime.Now}";
        }

        [HttpGet("random")]
        public int GetRandom()
        {
            return Random.Shared.Next(1, 100);
        }
        [HttpPost("greet")]
        public string PostGreeting([FromBody] string name)
        {
            return $"Hello, {name}! Posted at {DateTime.Now:HH:mm:ss}";
        }
    }
}
