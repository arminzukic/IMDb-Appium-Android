using System;
using IMDb_Appium_Android.Enums;
using IMDb_Appium_Android.Helpers;
using NUnit.Framework;

namespace IMDb_Appium_Android.Test;

public class Examples
{
    [Test]
    public void ApiTest()
    {
        var ratings = RapidApi.GetRatings(Movies.ApocalypseNow);
        Console.WriteLine($"IMDb Rating: {ratings.Item1}");
        Console.WriteLine($"Metascore Rating: {ratings.Item2}");
    }
}
