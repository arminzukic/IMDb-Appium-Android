using System.Collections.Generic;

namespace IMDb_Appium_Android.Models;

public class Cast
{
    public string category { get; set; }
    public List<string> characters { get; set; }
    public List<Role> roles { get; set; }
}