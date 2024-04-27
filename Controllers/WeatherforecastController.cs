using Method;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Controller;

[ApiController]
[Route("/api/[controller]/[action]")]
public class WeatherforecastController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Weather>> GetWeather()
    {
        Weather weather = await WeatherAction.GetWeather();
        return weather;
    }
}