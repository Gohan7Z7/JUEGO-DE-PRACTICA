
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("HUD")]
    public TMP_Text textoTiempo;
    public TMP_Text textoVidas;
    public TMP_Text textoFrutas;
    public GameObject panelGameOver;
    public GameObject panelVictoria;

    [Header("Configuracion del juego")]
    public float tiempoInicial = 240f;
    public int vidas = 3;

    private int totalFruits;
    private int fruitsCollected = 0;
    private float tiempoRestante;
    private bool juegoTerminado = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        totalFruits = FindObjectsByType<FruitCollector>(
            FindObjectsSortMode.None
        ).Length;

        tiempoRestante = tiempoInicial;

        if (panelGameOver != null)
        {
            panelGameOver.SetActive(false);
        }

        if (panelVictoria != null)
        {
            panelVictoria.SetActive(false);
        }

        ActualizarHUD();

        Debug.Log("Frutas totales: " + totalFruits);
    }

    void Update()
    {
        if (juegoTerminado)
            return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            MostrarGameOver();
        }

        ActualizarHUD();
    }

    public void FruitCollected()
    {
        if (juegoTerminado)
            return;

        fruitsCollected++;

        Debug.Log("Frutas recogidas: " + fruitsCollected + " / " + totalFruits);

        ActualizarHUD();

        if (fruitsCollected >= totalFruits)
        {
            MostrarVictoria();
        }
    }
    public void PerderVida()
    {
        if (juegoTerminado)
            return;

        vidas--;

        if (vidas < 0)
            vidas = 0;

        ActualizarHUD();

        Debug.Log("Vidas restantes: " + vidas);

        if (vidas <= 0)
        {
            MostrarGameOver();
        }
    }
    void MostrarGameOver()
    {
        juegoTerminado = true;

        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }

        Debug.Log("¡GAME OVER!");
    }
    void MostrarVictoria()
    {
        juegoTerminado = true;

        if (panelVictoria != null)
        {
            panelVictoria.SetActive(true);
        }

        Debug.Log("¡GANASTE!");
    }
    void ActualizarHUD()
    {
        if (textoTiempo != null)
        {
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);

            textoTiempo.text = string.Format(
                "Tiempo: {0:00}:{1:00}",
                minutos,
                segundos
            );
        }

        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidas;
        }

        if (textoFrutas != null)
        {
            textoFrutas.text = "Frutas: " + fruitsCollected + " / " + totalFruits;
        }
    }
    public void ReintentarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
