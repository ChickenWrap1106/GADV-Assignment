using UnityEngine;       // Import Unity’s core library (needed for MonoBehaviour, GameObject, Time, etc.)
using UnityEngine.UI;    // Import Unity’s UI library (needed for Button and Text components)

public class PauseManager : MonoBehaviour   // Define a class called PauseManager that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    public Button pauseButton;          // Reference to the UI Button that toggles pause/resume. Assigned in the Inspector.
    public Text buttonText;             // Optional reference to a Text element that displays "Pause" or "Resume".
    public PlayerCtrl playerCtrl;       // Reference to the PlayerCtrl script. Drag the Player GameObject here in the Inspector.

    private bool isPaused = false;      // Boolean flag to track whether the game is currently paused.

    void Start()                        // Unity’s Start() method runs once at the beginning of the game.
    {
        pauseButton.onClick.AddListener(TogglePause); 
        // Hook up the button’s OnClick event so that clicking the button calls TogglePause().
    }

    public void TogglePause()           // Method that toggles between pausing and resuming the game.
    {
        if (isPaused)                   // If the game is currently paused…
        {
            Time.timeScale = 1f;        // Resume the game by setting time scale back to normal speed (1).
            playerCtrl.enabled = true;  // Re-enable the PlayerCtrl script so the player can move again.

            if (buttonText != null)     // If a Text element is assigned…
            {
                buttonText.text = "Pause"; // …update the button label to show "Pause".
            }

            isPaused = false;           // Update the flag to indicate the game is no longer paused.
        }
        else                            // If the game is currently running…
        {
            Time.timeScale = 0f;        // Pause the game by setting time scale to 0 (freezes physics, animations, coroutines).
            playerCtrl.enabled = false; // Disable the PlayerCtrl script so the player cannot move.

            if (buttonText != null)     // If a Text element is assigned…
            {
                buttonText.text = "Resume"; // …update the button label to show "Resume".
            }

            isPaused = true;            // Update the flag to indicate the game is now paused.
        }
    }
}
