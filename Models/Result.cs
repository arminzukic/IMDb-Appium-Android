using System.Collections.Generic;

namespace IMDb_Appium_Android.Models;

public class Result
{
    public string id { get; set; }
    public Image image { get; set; }
    public int runningTimeInMinutes { get; set; }
    public string title { get; set; }
    public string titleType { get; set; }
    public int year { get; set; }
    public List<Principal> principals { get; set; }
    public string nextEpisode { get; set; }
    public int? numberOfEpisodes { get; set; }
    public int? seriesStartYear { get; set; }
    public int? seriesEndYear { get; set; }
    public string legacyNameText { get; set; }
    public string name { get; set; }
    public List<KnownFor> knownFor { get; set; }
}