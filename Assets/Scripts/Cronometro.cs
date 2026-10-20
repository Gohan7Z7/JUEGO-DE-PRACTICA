using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public TMP_Text textoTiempo;

    private float tiempoTranscurrido = 0f;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);

        textoTiempo.text = string.Format(
            "Tiempo: {0:00}:{1:00}",
            minutos,
            segundos
        );
    }
}