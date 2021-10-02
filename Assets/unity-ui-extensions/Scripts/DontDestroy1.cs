using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DontDestroy1 : MonoBehaviour {

    static DontDestroy1 perma;
    public bool activate_game;
    static TiempoNiveles niveles;

    void Start()
    {
        if (perma != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            perma = this;
        }
        
    }

    private void Update()
    {
        if (activate_game)
        {
            this.gameObject.SetActive(false);
        }
        else if (!activate_game)
        {
            return;
        }

    }
    
}

