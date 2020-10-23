using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleStore.Infrastructure;

namespace simplestore.Controllers
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
        private readonly SimpleStoreDbContext _context;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            SimpleStoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            //var consecutive = _context.Consecutives.Single(consecutive => consecutive.Table == "Movie");

            //var movie = new object();
            //movie.Id = $"{consecutive.Prefix}-{consecutive.Current + 1}";

            //consecutive.Current += 1;


            //var exampleUser = new User(
            //"a@gmail.com",
            //"123");

            //var user = _context.Users.Single(user => user.Email == "a@gmail.com");

            //_context.Users.Add(exampleUser);
            //_context.SaveChanges();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
