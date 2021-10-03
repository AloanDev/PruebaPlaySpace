using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject playButton;
    
    private void Awake()
    {
        playButton.GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.GameScene);
        playButton.GetComponent<Button_UI>().AddButtonSounds();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Loading");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    
}
