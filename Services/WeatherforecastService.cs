using System.Net;
using Newtonsoft.Json;
using Method;
using Model;

namespace Services;

public class WeatherforecastService
{
    private static readonly DBConfig db;
    // private static readonly Logger log;
    public static async Task<Weather> GetWeather()
    {
        HttpClient client = new(new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip
        })
        {
            BaseAddress = new Uri("https://devapi.qweather.com")
        };
        var result = await client.GetAsync(String.Format("/v7/weather/3d?location=101040700&key=7289a03ee57b45348a1c32133a664eb5"));
        var weather = await result.Content.ReadAsStringAsync();
        JsonData today = JsonConvert.DeserializeObject<JsonData>(weather);
        Logger.logger.Info($"Get {today.daily[0].fxDate}'s weather");
        return AddWeather(today.daily[0]);
    }
    public static Weather AddWeather(Weather weather)
    {
        db.Weathers.Add(weather);
        db.SaveChanges();
        return weather;
    }
    public static Weather GetWeatherFromDB()
    {
        string date = DateTime.Today.ToString("yyyy-MM-dd");
        System.Console.WriteLine(date);
        return db.Weathers.SingleOrDefault(weather => weather.fxDate == date);
    }
    public static List<Weather> GetWeathersFromDB()
    {
        return [.. db.Weathers];
    }
}
