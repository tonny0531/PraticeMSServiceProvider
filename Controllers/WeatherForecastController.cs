using Microsoft.AspNetCore.Mvc;
using ServiceProviderTest.Services;

namespace ServiceProviderTest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IServiceA sa;
    private readonly IServiceB sb;
    public WeatherForecastController(ILogger<WeatherForecastController> logger,IServiceA sa, IServiceB sb)
    {
        _logger = logger;
        this.sa = sa;
        this.sb = sb;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        this.sa.GetServiceName();
        this.sb.GetServiceName();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
