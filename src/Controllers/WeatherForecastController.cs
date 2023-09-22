using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenApiSample.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
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

    [HttpGet(Name = "GetWeatherData")]
    [SwaggerOperation(summary: "Get Weather Data", description: "Weather related data description")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<NewWeatherForecast>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
    public IEnumerable<NewWeatherForecast> GetWeather()
    {
        return Enumerable.Range(1, 5).Select(index => new NewWeatherForecast
            {
                NewDate = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                NewSummary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}