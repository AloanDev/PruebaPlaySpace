
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Works alongside the Loader class to notify it when the current level has updated the screen
 * */
public class LoaderCallback : MonoBehaviour {

    private bool firstUpdate = true;
    private float timer = 3f;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("Game");
            timer = 0;
        }
    }
}
