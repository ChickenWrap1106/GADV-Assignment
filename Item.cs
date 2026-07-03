using UnityEngine;

public class Item : MonoBehaviour
{

    // Use this if "Is Trigger" is CHECKED
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))

        {
            Destroy(gameObject);
            GameManager.instance.AddPoint();
        }
    }
}