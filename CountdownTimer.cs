using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; // <-- Add this

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float timeRemaining = 60f; 
    [SerializeField] private bool timerIsRunning = true;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI timeText;

    [Header("End Scene Settings")]
    [SerializeField] private int endSceneIndex = 1; // Scene index to load when time runs out

    // Event declaration so other scripts can react when timer ends
    public delegate void TimerEnded();
    public event TimerEnded OnTimerEndEvent;

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                DisplayTime(timeRemaining);

                // Fire event
                OnTimerEndEvent?.Invoke();

                // Load scene instead of spawning prefab
                LoadEndScene();
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void LoadEndScene()
    {
        SceneManager.LoadScene(endSceneIndex);
    }
}
