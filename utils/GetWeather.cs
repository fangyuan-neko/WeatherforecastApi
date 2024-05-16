using System.Net;
using Newtonsoft.Json;
using Model;
using Services;

namespace Method;

public class WeatherAction(WeatherforecastService weatherforecastService)
{
    private static async Task<Weather> DownloadWeather()
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
        return today.daily[0];
    }
    public async Task<Weather> GetWeather()
    {
        var weatherInDB = weatherforecastService.GetWeatherFromDB();
        if (weatherInDB == null)
        {
            var weather = await DownloadWeather();
            return weatherforecastService.AddWeather(weather);
        }
        else
        {
            return weatherInDB;
        }
    }
}