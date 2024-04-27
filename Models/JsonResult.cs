namespace Model;

public struct JsonData
{
    public int code { get; set; }
    public string updateTime { get; set; }
    public string fxLink { get; set; }
    public List<Weather> daily { get; set; }
}