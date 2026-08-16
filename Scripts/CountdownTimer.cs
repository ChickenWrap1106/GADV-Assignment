using UnityEngine;                 // Import Unity’s core library (needed for MonoBehaviour, GameObject, Time, etc.)
using TMPro;                       // Import TextMeshPro library (needed for UI text elements)
using UnityEngine.SceneManagement; // Import SceneManagement (needed for loading new scenes)

public class CountdownTimer : MonoBehaviour   // Define a class called CountdownTimer that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    [Header("Timer Settings")]                // Creates a header in the Unity Inspector to group timer-related variables.
    [SerializeField] private float timeRemaining = 60f; // Starting time in seconds. Editable in Inspector.
    [SerializeField] private bool timerIsRunning = true; // Flag to control whether the timer is active.

    [Header("UI Elements")]                   // Header for UI-related variables.
    [SerializeField] private TextMeshProUGUI timeText; // Reference to the TextMeshProUGUI element that displays the countdown.

    [Header("End Scene Settings")]            // Header for scene transition settings.
    [SerializeField] private int endSceneIndex = 1; // Scene index to load when the timer reaches zero. Set in Build Settings.

    // Event declaration so other scripts can react when the timer ends.
    public delegate void TimerEnded();        // Define a delegate type for timer end events.
    public event TimerEnded OnTimerEndEvent;  // Event that other scripts can subscribe to.

    private void Update()                     // Unity’s Update() method runs every frame.
    {
        if (timerIsRunning)                   // Only run timer logic if the timer is active.
        {
            if (timeRemaining > 0)            // If there is still time left…
            {
                timeRemaining -= Time.deltaTime; // Subtract the time passed since the last frame.
                DisplayTime(timeRemaining);      // Update the UI text with the new time.
            }
            else                              // If the timer has run out…
            {
                Debug.Log("Time has run out!"); // Log a message to the console for debugging.
                timeRemaining = 0;              // Clamp the timer to zero.
                timerIsRunning = false;         // Stop the timer.
                DisplayTime(timeRemaining);     // Update the UI to show "00:00".

                OnTimerEndEvent?.Invoke();      // Fire the event so other scripts can react (e.g., stop player movement).

                LoadEndScene();                 // Load the designated end scene.
            }
        }
    }

    private void DisplayTime(float timeToDisplay) // Method to format and display the remaining time.
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); // Convert seconds into minutes.
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Get the remainder seconds.

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        // Format the time as "MM:SS" and update the UI text.
    }

    private void LoadEndScene()               // Method to handle scene transition when the timer ends.
    {
        SceneManager.LoadScene(endSceneIndex); // Load the scene at the specified index from Build Settings.
    }
}
