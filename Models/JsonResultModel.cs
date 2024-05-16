using System.ComponentModel.DataAnnotations;

namespace Model;

public class JsonData
{
    public int code { get; set; }
    [Key]
    public string updateTime { get; set; }
    public string fxLink { get; set; }
    public List<Weather> daily { get; set; }
}