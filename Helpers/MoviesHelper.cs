using System.Collections.Generic;
using IMDb_Appium_Android.Enums;

namespace IMDb_Appium_Android.Helpers;

public static class MoviesHelper
{
    private static readonly Dictionary<Movies, string> Titles = new()
    {
        {Movies.TheLordOfTheRingsReturnOfTheKing, "The Lord of the Rings: The Return of the King"},
        {Movies.Inception, "Inception"},
        {Movies.ApocalypseNow, "Apocalypse Now"},
        {Movies.LostInTranslation, "Lost in Translation"},
        {Movies.BlackHawkDawn, "Black Hawk Down"},
        {Movies.ManchesterByTheSea, "Manchester by the Sea"},
        {Movies.TheThinRedLine, "The Thin Red Line"},
        {Movies.TheNorthman, "The Northman"},
        {Movies.TheLastOfTheMohicans, "The Last of the Mohicans"},
        {Movies.JurassicPark, "Jurassic Park"},
        {Movies.TheBatman, "The Batman"},
        {Movies.Dune, "Dune"},
        {Movies.EternalSunshineOfASpotlessMind, "Eternal Sunshine of the Spotless Mind"},
        {Movies.GoodWillHunting, "Good Will Hunting"},
        {Movies.Gladiator, "Gladiator"}
    };

    private static readonly Dictionary<Movies, string> Years = new()
    {
        {Movies.TheLordOfTheRingsReturnOfTheKing, "2003"},
        {Movies.Inception, "2010"},
        {Movies.ApocalypseNow, "1979"},
        {Movies.LostInTranslation, "2003"},
        {Movies.BlackHawkDawn, "2001"},
        {Movies.ManchesterByTheSea, "2016"},
        {Movies.TheThinRedLine, "1998"},
        {Movies.TheNorthman, "2022"},
        {Movies.TheLastOfTheMohicans, "1992"},
        {Movies.JurassicPark, "1993"},
        {Movies.TheBatman, "2022"},
        {Movies.Dune, "2021"},
        {Movies.EternalSunshineOfASpotlessMind, "2004"},
        {Movies.GoodWillHunting, "1997"},
        {Movies.Gladiator, "2000"}
    };

    public static string GetMovieTitle(this Movies movie)
    {
        return Titles[movie];
    }

    public static string GetMovieYear(this Movies movie)
    {
        return Years[movie];
    }
}