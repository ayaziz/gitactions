using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;

namespace GitActions.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            
            using (var connection = new SqlConnection("Server=tcp:sqlazewtmlns001scmshard.database.windows.net,1433;Initial Catalog=sqdazewtmlns001destcr;Persist Security Info=False;User ID=SQL_Destination_Admin_CR;Password=X1Zkk1dvS7FmO9vHapAhNJqUk4LU8pcCGYXXZhcFWtFsO;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                connection.Open();
                using (var command = new SqlCommand($"insert int  * from temp where id={10}", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = new Random().Next(-20, 55),
                Summary = Summaries[new Random().Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}