using UnityEngine;
using UnityEngine.SceneManagement;
public class TiempoNiveles : MonoBehaviour
{

    public string nivelACargar;
    public float retraso;
    DontDestroy1 destroy;
    [ContextMenu("SCROLLMENU")]
    private void Start()
    {
        destroy = GetComponent<DontDestroy1>();
    }

    public void ActivarCarga()
    {
        Invoke("CargarNivel", retraso);
    }

    void CargarNivel()
    {
        SceneManager.LoadScene(nivelACargar);
        if (nivelACargar == ("Game"))
        {
            destroy.activate_game = true;
        }

    }

}