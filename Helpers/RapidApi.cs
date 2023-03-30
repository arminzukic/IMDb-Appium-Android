using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using IMDb_Appium_Android.Enums;
using IMDb_Appium_Android.Models;
using RestSharp;

namespace IMDb_Appium_Android.Helpers;

public static class RapidApi
{
    private const string _apiKey = "<API_KEY>";
    private const string _baseUrl = "https://imdb8.p.rapidapi.com";
    
    private const string _movieIdParam = "tconst";
    private const string _movieTitleParam = "q";
    
    private const string _getMetacriticResource = "get-metacritic";
    private const string _getRatingResource = "get-ratings";
    private const string _getFindResource = "find";
    
    private static readonly RestClient _client;
    
    static RapidApi()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        _client = new RestClient(_baseUrl);
    }
    
    public static Tuple<float, int> GetRatings(Movies movie)
    {
        var movieId = GetMovieId(movie.GetMovieTitle(),
            int.Parse(movie.GetMovieYear()));
        
        return new Tuple<float, int>(GetImdbRating(movieId), GetMetaCriticRating(movieId));
    }

    private static string? GetMovieId(string movieTitle, int movieYear)
    {
        var request = CreateRequest(_getFindResource, _movieTitleParam, movieTitle);
        var response = _client.GetAsync<FindByTitleResponse>(request);
        var movie = response.Result?.results.
            FirstOrDefault(movie => movie.year == movieYear && movie.title == movieTitle);
        
        return movie?.id.Split("/")[2];
    }
    
    private static float GetImdbRating(string? movieId)
    {
        var request = CreateRequest(_getRatingResource, _movieIdParam, movieId);
        var response = _client.GetAsync<GetRatingResponse>(request);
        Console.WriteLine($"IMDb API: {response.Result!.rating}");
        
        return (float) response.Result!.rating;
    }
    
    private static int GetMetaCriticRating(string? movieId)
    {
        var request = CreateRequest(_getMetacriticResource, _movieIdParam, movieId);
        var response = _client.GetAsync<GetMetacriticResponse>(request);
        Console.WriteLine($"MetaCritic API: {response.Result!.metaScore}");
        
        return response.Result!.metaScore;
    }

    private static RestRequest CreateRequest(string resource, string paramName, string? paramValue)
    {
        return new RestRequest($"/title/{resource}")
            .AddHeader("X-RapidAPI-Key", _apiKey)
            .AddParameter(paramName, paramValue);
    }
}