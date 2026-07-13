using UnityEngine;
using TMPro; // Required for TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float timeRemaining = 60f; // Set starting time in seconds
    [SerializeField] private bool timerIsRunning = true;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Subtract the time passed since the last frame
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                DisplayTime(timeRemaining);
                OnTimerEnd();
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        // Calculate minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Format string as "00:00"
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTimerEnd()
    {
        // Add your custom logic here (e.g., Load Game Over Scene, PlayerDeath(), etc.)
    }
}
