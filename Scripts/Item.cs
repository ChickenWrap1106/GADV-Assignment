using UnityEngine;   // Import Unity’s core library (needed for MonoBehaviour, GameObject, Collider2D, etc.)

public class Item : MonoBehaviour   // Define a class called Item that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    [SerializeField] private int pointValue = 1; 
    // Private variable that sets how many points this item is worth.
    // [SerializeField] makes it visible in the Inspector so you can assign different values per item prefab.
    // Default value is 1 point.

    private void OnTriggerEnter2D(Collider2D other)   // Unity event method: called automatically when another Collider2D enters this trigger zone.
    {
        if (other.CompareTag("Player"))              // Check if the object that entered has the tag "Player".
        {
            Destroy(gameObject);                     // Remove this item from the scene once collected.
            GameManager.instance.AddPoint(pointValue); 
            // Call the AddPoint() method in GameManager, passing in this item’s pointValue.
            // This increases the player’s score by the correct amount.
        }
    }
}
