using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProducts;

using MediatR;
using Microsoft.AspNetCore.Mvc;
//using Services.Cars.Queries.GetAllCars;

namespace AnyBuyStore.Controllers
{

    public class WeatherForecastController : BaseApiController
    {
        public WeatherForecastController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get(string cityName)
        {

            if (cityName == "sydney")
            {
                throw new Exception("no weather data for sydney");
            }
            var rnf = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = rnf.Next(-20, 55),
                Summary = Summaries[rnf.Next(Summaries.Length)]

            }).ToArray();

        }

    }




}