
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float tiempoProteccion = 1f;

    private bool puedeRecibirDanio = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!puedeRecibirDanio)
            return;

        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Danger"))
        {
            GameManager.instance.PerderVida();

            puedeRecibirDanio = false;

            Invoke(nameof(ActivarDanio), tiempoProteccion);
        }
    }

    void ActivarDanio()
    {
        puedeRecibirDanio = true;
    }
}
