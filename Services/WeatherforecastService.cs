using Method;
using Model;

namespace Services;

public class WeatherforecastService(DBConfig database)
{
    private readonly DBConfig db = database;
    public Weather AddWeather(Weather weather)
    {
        db.Weathers.Add(weather);
        db.SaveChanges();
        return weather;
    }
    public Weather GetWeatherFromDB()
    {
        string date = DateTime.Today.ToString("yyyy-MM-dd");
        return db.Weathers.SingleOrDefault(weather => weather.fxDate == date);
    }
}
