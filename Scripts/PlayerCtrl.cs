using UnityEngine;          // Import Unity’s core library (needed for MonoBehaviour, GameObject, Rigidbody2D, etc.)
using System.Collections;   // Import System.Collections (needed for coroutines like IEnumerator)

public class PlayerCtrl : MonoBehaviour   // Define a class called PlayerCtrl that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    public float moveSpeed = 10f;         // Public variable that sets how fast the player moves. Visible in the Unity Inspector.

    [HideInInspector]                     // Attribute hides this variable from the Inspector but keeps it accessible in code.
    public float defaultSpeed;            // Stores the original speed value so it can be restored later (e.g., after slowing down).

    private Rigidbody2D rb;               // Reference to the Rigidbody2D component (handles physics-based movement).
    private float speedX;                 // Stores horizontal input value (-1, 0, or 1).
    private float speedY;                 // Stores vertical input value (-1, 0, or 1).

    private bool isStunned = false;       // Boolean flag to check if the player is stunned. If true, movement is disabled.

    void Start()                          // Unity’s Start() method runs once at the beginning of the game.
    {
        rb = GetComponent<Rigidbody2D>(); // Get and store the Rigidbody2D component attached to the player GameObject.
        defaultSpeed = moveSpeed;         // Save the initial moveSpeed value into defaultSpeed for later use.
    }

    void Update()                         // Unity’s Update() method runs every frame (used for input handling).
    {
        if (isStunned)                    // If the player is stunned…
        {
            speedX = 0;                   // …set horizontal input to 0 (no movement).
            speedY = 0;                   // …set vertical input to 0 (no movement).
            return;                       // Exit the Update() method early so no input is processed.
        }

        speedX = Input.GetAxisRaw("Horizontal"); // Read raw horizontal input (left/right arrow keys or A/D).
        speedY = Input.GetAxisRaw("Vertical");   // Read raw vertical input (up/down arrow keys or W/S).
    }

    void FixedUpdate()                    // Unity’s FixedUpdate() method runs at fixed intervals (used for physics updates).
    {
        if (isStunned)                    // If the player is stunned…
        {
            rb.linearVelocity = Vector2.zero; // …stop all movement by setting velocity to zero.
        }
        else
        {
            rb.linearVelocity = new Vector2(speedX * moveSpeed, speedY * moveSpeed); 
            // Otherwise, apply velocity based on input and moveSpeed.
            // Example: pressing right sets speedX = 1, so velocity becomes (10, 0).
        }
    }

    public void Stun(float duration)      // Public method to stun the player for a given duration (called by other scripts).
    {
        StartCoroutine(StunCoroutine(duration)); // Start a coroutine that handles the stun effect over time.
    }

    IEnumerator StunCoroutine(float duration)   // Coroutine that temporarily disables movement.
    {
        isStunned = true;                 // Set stunned flag to true (player can’t move).
        rb.linearVelocity = Vector2.zero; // Immediately stop movement.

        yield return new WaitForSeconds(duration); // Wait for the given duration before continuing.

        isStunned = false;                // Reset stunned flag to false (player can move again).
    }
}
