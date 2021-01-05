using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///
/// Global game settings
///
public static class ConfigData
{
    private static ConfigureSettings data;
    // private static string game_difficulty = "easy";
    private static string game_difficulty = "easy";
    public static void initialize()
    {
        if (data == null)
        {
            data = new ConfigureSettings();
        }
    }

    public static string GetValue(string target, string key)
    {
        initialize();
        return data.GetValue(target, key);
    }

    public static void SetDifficulty(string difficulty)
    {
        if (difficulty == "hard")
        {
            game_difficulty = difficulty;
        }
        else
        {
            game_difficulty = "easy";
        }
    }
    
    public static string GetDifficulty()
    {
        return game_difficulty;
    }
}
