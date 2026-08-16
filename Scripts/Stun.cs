using UnityEngine;   // Import Unity’s core library (needed for MonoBehaviour, GameObject, Collision2D, etc.)

public class Stun : MonoBehaviour   // Define a class called Stun that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    public float stunDuration = 2f;   // Public variable that sets how long the player will be stunned (in seconds). Visible in the Unity Inspector.

    private void OnCollisionEnter2D(Collision2D collision)   // Unity event method: called automatically when this GameObject collides with another Collider2D.
    {
        PlayerCtrl player = collision.gameObject.GetComponent<PlayerCtrl>(); 
        // Try to get the PlayerCtrl script from the object that was hit in the collision.
        // This checks if the collided object is the player.

        if (player != null)   // If the collided object has a PlayerCtrl component (meaning it’s the player)…
        {
            player.Stun(stunDuration); 
            // Call the Stun() method on the player, passing in the stunDuration value.
            // This disables the player’s movement for the specified duration.
        }
    }
}
