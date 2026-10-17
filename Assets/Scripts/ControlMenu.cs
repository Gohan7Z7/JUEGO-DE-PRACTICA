using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("NivelUno");
    }
}
public void VolverAlMenu()
{
    UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicial");
}

