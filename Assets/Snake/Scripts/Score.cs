/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static event EventHandler OnHighscoreChanged;

    private static int gems;
    private static int coins;

    public static void InitializeStatic()
    {
        OnHighscoreChanged = null;
        gems = 0;
        coins = 0;
    }

    public static int GetScoreGem()
    {
        return gems;
    }

    public static int GetScoreCoin()
    {
        return coins;
    }

    public static void AddScore()
    {
        gems += 1;
    }

    public static void AddScoreCoin()
    {
        coins += 1;
    }

    public static int GetHighscoreGems()
    {
        return PlayerPrefs.GetInt("highscoreGems", 0);
    }

    public static int GetHighscoreCoins()
    {
        return PlayerPrefs.GetInt("highscoreCoins", 0);
    }

    public static bool TrySetNewHighscoreGems()
    {
        return TrySetNewHighscoreGems(gems);
    }

    public static bool TrySetNewHighscoreCoins()
    {
        return TrySetNewHighscoreCoins(coins);
    }


    public static bool TrySetNewHighscoreGems(int score)
    {
        int highscore = GetHighscoreGems();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscoreGems", score);
            PlayerPrefs.Save();
            if (OnHighscoreChanged != null) OnHighscoreChanged(null, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool TrySetNewHighscoreCoins(int score)
    {
        int highscore = GetHighscoreCoins();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscoreCoin", score);
            PlayerPrefs.Save();
            if (OnHighscoreChanged != null) OnHighscoreChanged(null, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }
}