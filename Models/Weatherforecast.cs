namespace Model;

public struct Weather
{
    public string fxDate { get; set; }
    public string sunrise { get; set; }
    public string sunset { get; set; }
    public string moonrise { get; set; }
    public string moonset { get; set; }
    public string moonPlase { get; set; }
    public int moonPlaseIcon { get; set; }
    public int tempMax { get; set; }
    public int tempMin { get; set; }
    public int iconDay { get; set; }
    public string textDay { get; set; }
    public int iconNight { get; set; }
    public string textNight { get; set; }
    public int wind360Day { get; set; }
    public string windDirDay { get; set; }
    public string windScaleDay { get; set; }
    public int windSpeedDay { get; set; }
    public int wind360Night { get; set; }
    public string windDirNight { get; set; }
    public string windScaleNight { get; set; }
    public int windSpeedNight { get; set; }
    public int humidity { get; set; }
    public double precip { get; set; }
    public int pressure { get; set; }
    public int vis { get; set; }
    public int cloud { get; set; }
    public int uvIndex { get; set; }
}