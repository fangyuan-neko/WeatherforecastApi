using Method;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace Controller;

[ApiController]
[Route("api/[action]")]
public class WeatherforecastController(Logger log, DBConfig database, WeatherAction weatherAction, WeatherforecastService weatherforecastService) : ControllerBase
{
    private readonly Logger log = log;
    private readonly WeatherAction WeatherAction = weatherAction;
    private readonly WeatherforecastService WeatherforecastService = weatherforecastService;
    [HttpGet]
    public async Task<ActionResult<Weather>> GetWeather()
    {
        // 先在数据库中查找有无此名，再看是否匹配
        foreach (var user in database.Users)
        {
            if (user.Token == Request.Headers.Authorization.ToString().Split(" ")[1])
            {
                Weather weather = await WeatherAction.GetWeather();
                log.logger.Debug("GetWeather");
                return weather;
            }
        }
        return new StatusCodeResult(401);
    }
    [HttpGet]
    public ActionResult<List<Weather>> GetWeathers()
    {
        // 先在数据库中查找有无此名，再看是否匹配
        foreach (var user in database.Users)
        {
            if (user.Token == Request.Headers.Authorization.ToString().Split(" ")[1])
            {
                return WeatherforecastService.GetWeathersFromDB();
            }
        }
        return new StatusCodeResult(401);
    }
}