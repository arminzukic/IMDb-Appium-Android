using Newtonsoft.Json;

namespace IMDb_Appium_Android.Models;

    public class Aged1829
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class Aged3044
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class Aged45
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class AgedUnder18
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class Females
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class FemalesAged1829
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class FemalesAged3044
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class FemalesAged45
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class FemalesAgedUnder18
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class Histogram
    {
        [JsonProperty("1")]
        public int _1 { get; set; }

        [JsonProperty("2")]
        public int _2 { get; set; }

        [JsonProperty("3")]
        public int _3 { get; set; }

        [JsonProperty("4")]
        public int _4 { get; set; }

        [JsonProperty("5")]
        public int _5 { get; set; }

        [JsonProperty("6")]
        public int _6 { get; set; }

        [JsonProperty("7")]
        public int _7 { get; set; }

        [JsonProperty("8")]
        public int _8 { get; set; }

        [JsonProperty("9")]
        public int _9 { get; set; }

        [JsonProperty("10")]
        public int _10 { get; set; }
    }

    public class IMDbStaff
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class IMDbUsers
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class Males
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class MalesAged1829
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class MalesAged3044
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class MalesAged45
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class MalesAgedUnder18
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class NonUSUsers
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class RatingsHistograms
    {
        [JsonProperty("Aged 30-44")]
        public Aged3044 Aged3044 { get; set; }

        [JsonProperty("Males Aged under 18")]
        public MalesAgedUnder18 MalesAgedunder18 { get; set; }

        [JsonProperty("IMDb Staff")]
        public IMDbStaff IMDbStaff { get; set; }
        public Males Males { get; set; }

        [JsonProperty("Females Aged under 18")]
        public FemalesAgedUnder18 FemalesAgedunder18 { get; set; }

        [JsonProperty("Non-US users")]
        public NonUSUsers NonUSusers { get; set; }

        [JsonProperty("Females Aged 18-29")]
        public FemalesAged1829 FemalesAged1829 { get; set; }

        [JsonProperty("IMDb Users")]
        public IMDbUsers IMDbUsers { get; set; }

        [JsonProperty("US users")]
        public USUsers USusers { get; set; }

        [JsonProperty("Females Aged 30-44")]
        public FemalesAged3044 FemalesAged3044 { get; set; }

        [JsonProperty("Aged under 18")]
        public AgedUnder18 Agedunder18 { get; set; }

        [JsonProperty("Males Aged 30-44")]
        public MalesAged3044 MalesAged3044 { get; set; }
        public Females Females { get; set; }

        [JsonProperty("Males Aged 45+")]
        public MalesAged45 MalesAged45 { get; set; }

        [JsonProperty("Aged 18-29")]
        public Aged1829 Aged1829 { get; set; }

        [JsonProperty("Males Aged 18-29")]
        public MalesAged1829 MalesAged1829 { get; set; }

        [JsonProperty("Females Aged 45+")]
        public FemalesAged45 FemalesAged45 { get; set; }

        [JsonProperty("Aged 45+")]
        public Aged45 Aged45 { get; set; }

        [JsonProperty("Top 1000 voters")]
        public Top1000Voters Top1000voters { get; set; }
    }

    public class GetRatingResponse
    {
        [JsonProperty("@type")]
        public string type { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string titleType { get; set; }
        public int year { get; set; }
        public int bottomRank { get; set; }
        public bool canRate { get; set; }
        public double rating { get; set; }
        public int ratingCount { get; set; }
        public RatingsHistograms ratingsHistograms { get; set; }
        public int topRank { get; set; }
    }

    public class Top1000Voters
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

    public class USUsers
    {
        public double aggregateRating { get; set; }
        public string demographic { get; set; }
        public Histogram histogram { get; set; }
        public int totalRatings { get; set; }
    }

