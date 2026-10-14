using UnityEngine;

public class FruitCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Avisa al GameManager que recogió una fruta
            if (GameManager.instance != null)
            {
                GameManager.instance.FruitCollected();
            }

            Destroy(gameObject);
        }
    }
}