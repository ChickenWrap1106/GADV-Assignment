using UnityEngine;   // Import Unity’s core library (needed for MonoBehaviour, GameObject, Collider2D, etc.)

public class SlowZone : MonoBehaviour   // Define a class called SlowZone that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    public float slowSpeed = 2f;        // Public variable that sets the reduced speed when the player enters the slow zone. Visible in the Unity Inspector.

    private void OnTriggerEnter2D(Collider2D other)   // Unity event method: called automatically when another Collider2D enters this trigger zone.
    {
        PlayerCtrl player = other.GetComponent<PlayerCtrl>(); // Try to get the PlayerCtrl script from the object that entered the trigger.

        if (player != null)             // If the object has a PlayerCtrl component (meaning it’s the player)…
        {
            player.moveSpeed = slowSpeed; // …reduce the player’s movement speed to the slowSpeed value.
        }
    }

    private void OnTriggerExit2D(Collider2D other)    // Unity event method: called automatically when another Collider2D exits this trigger zone.
    {
        PlayerCtrl player = other.GetComponent<PlayerCtrl>(); // Try to get the PlayerCtrl script from the object that exited the trigger.

        if (player != null)             // If the object has a PlayerCtrl component (meaning it’s the player)…
        {
            player.moveSpeed = player.defaultSpeed;   // …restore the player’s movement speed back to their original defaultSpeed.
        }
    }
}
