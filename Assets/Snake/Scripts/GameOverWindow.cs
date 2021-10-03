/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class GameOverWindow : MonoBehaviour
{
    private static GameOverWindow instance;

    private void Awake()
    {
        instance = this;

        transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene); };
        transform.Find("menu").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.MainMenu); };

        Hide();
    }

    private void Show(bool isNewHighscore)
    {
        gameObject.SetActive(true);

        transform.Find("newHighscoreGemsText").gameObject.SetActive(isNewHighscore);
        transform.Find("newHighscoreCoinsText").gameObject.SetActive(isNewHighscore);

        transform.Find("coinsText").GetComponent<TextMeshPro>().text = Score.GetScoreCoin().ToString();
        transform.Find("gemsText").GetComponent<TextMeshPro>().text = Score.GetScoreGem().ToString();
        transform.Find("highscoreCoinsText").GetComponent<TextMeshPro>().text =
            "HIGHSCORE COINS" + Score.GetHighscoreCoins();
        transform.Find("highscoreGemsText").GetComponent<TextMeshPro>().text =
            "HIGHSCORE GEMS" + Score.GetHighscoreGems();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic(bool isNewHighscore)
    {
        instance.Show(isNewHighscore);
    }
}