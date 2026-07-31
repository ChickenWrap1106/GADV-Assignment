using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button pauseButton;          // Assign in Inspector
    public Text buttonText;             // Optional: shows "Pause"/"Resume"
    public PlayerCtrl playerCtrl;       // Drag your PlayerCtrl here in Inspector

    private bool isPaused = false;

    void Start()
    {
        // Hook up button click
        pauseButton.onClick.AddListener(TogglePause);
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            // Resume game
            Time.timeScale = 1f;
            playerCtrl.enabled = true;   // Re-enable movement script
            if (buttonText != null) 
            {
                buttonText.text = "Pause";
            }
            isPaused = false;
        }
        else
        {
            // Pause game
            Time.timeScale = 0f;
            playerCtrl.enabled = false;  // Disable movement script
            if (buttonText != null) 
            {
                buttonText.text = "Resume";
            }
            isPaused = true;
        }
    }
}
