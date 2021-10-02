﻿/* 
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
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    private static GameHandler instance;

    [SerializeField] private Snake snake;

    private LevelGrid levelGrid;

    private void Awake() {
        instance = this;
        Score.InitializeStatic();
        Time.timeScale = 1f;
    }

    private void Start() {
        Debug.Log("GameHandler.Start");

        levelGrid = new LevelGrid(40, 18);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (IsGamePaused()) {
                GameHandler.ResumeGame();
            } else {
                GameHandler.PauseGame();
            }
        }
    }

    public static void SnakeDied() {
        bool isNewHighscoreGems = Score.TrySetNewHighscoreGems();
        bool isNewHighscoreCoins = Score.TrySetNewHighscoreCoins();
        GameOverWindow.ShowStatic(isNewHighscoreGems);
        GameOverWindow.ShowStatic(isNewHighscoreCoins);
        ScoreWindow.HideStatic();
    }

    public static void ResumeGame() {
        PauseWindow.HideStatic();
        Time.timeScale = 1f;
    }

    public static void PauseGame() {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }

    public static bool IsGamePaused() {
        return Time.timeScale == 0f;
    }
}