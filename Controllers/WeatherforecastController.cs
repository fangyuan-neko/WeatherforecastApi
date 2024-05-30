using Method;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace Controller;

[ApiController]
[Route("api/[action]")]
public class WeatherforecastController(DBConfig database) : ControllerBase
{
    [HttpGet]
    public ActionResult<Weather> GetTodaysWeather()
    {
        // 先在数据库中查找有无此名，再看是否匹配
        foreach (var user in database.Users)
        {
            if (user.Token == Request.Headers.Authorization.ToString().Split(" ")[1])
            {
                Weather weather = WeatherforecastService.GetWeatherFromDB();
                Logger.logger.Debug("GetWeather");
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
                Logger.logger.Debug("GetWeathers");
                return WeatherforecastService.GetWeathersFromDB();
            }
        }
        return new StatusCodeResult(401);
    }
}