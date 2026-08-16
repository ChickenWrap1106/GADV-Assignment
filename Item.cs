using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int pointValue = 1; // Default is 1, can change in Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.instance.AddPoint(pointValue); // Pass value to GameManager
        }
    }
}
