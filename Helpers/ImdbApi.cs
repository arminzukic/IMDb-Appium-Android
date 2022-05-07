using System;
using System.Linq;
using System.Threading.Tasks;
using IMDbApiLib;
using IMDbApiLib.Models;

namespace IMDb_Appium_Android.Helpers;

public static class ImdbApi
{
    private const string ApiKey = "<IMDb_API_KEY>";

    private static readonly ApiLib ApiLib;

    static ImdbApi()
    {
        ApiLib = new ApiLib(ApiKey);
    }

    private static async Task<string?> GetMovieId(string movieName, string year)
    {
        var searchData = await ApiLib.SearchMovieAsync(movieName);
        var result = searchData.Results.FirstOrDefault(searchResult => searchResult.Description.Contains(year));

        return result?.Id;
    }

    public static async Task<RatingData> GetRatings(string movieName, string year)
    {
        return await ApiLib.RatingsAsync(await GetMovieId(movieName, year));
    }

    public static float GetImdbRating(Task<RatingData> rating)
    {
        Console.WriteLine($"IMDb API Rating: {rating.Result.IMDb}");

        return float.Parse(rating.Result.IMDb);
    }
    
    public static int GetMetaCriticRating(Task<RatingData> rating)
    {
        Console.WriteLine($"MetaCritic API Rating: {rating.Result.Metacritic}");
        
        return int.Parse(rating.Result.Metacritic);
    }
}