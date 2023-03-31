using System.Collections.Generic;

namespace IMDb_Appium_Android.Models;

public class Summary
{
    public string category { get; set; }
    public List<string> characters { get; set; }
    public string displayYear { get; set; }
}