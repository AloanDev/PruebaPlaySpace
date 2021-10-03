using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Works alongside the Loader class to notify it when the current level has updated the screen
 * */
public class LoaderCallback : MonoBehaviour
{
    private bool firstUpdate = true;
    private float timer = 2f;

    private void Update()
    {
        Time.timeScale = 1f;
        timer -= Time.deltaTime;
        if (firstUpdate && timer <= 0)
        {
            firstUpdate = false;
            Loader.LoaderCallback();
            timer = 0;
        }
    }
}