using System.Collections.Generic;

namespace IMDb_Appium_Android.Models;

public class KnownFor
{
    public List<Cast> cast { get; set; }
    public Summary summary { get; set; }
    public string id { get; set; }
    public string title { get; set; }
    public string titleType { get; set; }
    public int year { get; set; }
}