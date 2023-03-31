using System.Collections.Generic;

namespace IMDb_Appium_Android.Models;

public class Principal
{
    public string id { get; set; }
    public string legacyNameText { get; set; }
    public string name { get; set; }
    public int billing { get; set; }
    public string category { get; set; }
    public List<string> characters { get; set; }
    public List<Role> roles { get; set; }
    public string disambiguation { get; set; }
    public string @as { get; set; }
    public int? endYear { get; set; }
    public int? episodeCount { get; set; }
    public int? startYear { get; set; }
    public List<string> attr { get; set; }
}