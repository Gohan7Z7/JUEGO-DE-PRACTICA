using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int totalFruits;
    private int fruitsCollected = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Cuenta cuantas frutas hay al empezar
        totalFruits = FindObjectsByType<FruitCollector>(FindObjectsSortMode.None).Length;
        Debug.Log("Frutas totales: " + totalFruits);
    }

    public void FruitCollected()
    {
        fruitsCollected++;
        Debug.Log("Frutas recogidas: " + fruitsCollected + " / " + totalFruits);

        if (fruitsCollected >= totalFruits)
        {
            Debug.Log("¡GANASTE!");
            // Mas adelante pondremos la pantalla de victoria
        }
    }
}