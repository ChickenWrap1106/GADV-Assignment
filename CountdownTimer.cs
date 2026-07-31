using UnityEngine;
using TMPro; // Required for TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float timeRemaining = 60f; // Starting time in seconds
    [SerializeField] private bool timerIsRunning = true;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI timeText;

    [Header("End Message")]
    [SerializeField] private GameObject endMessagePrefab; // Assign a prefab with TextMeshProUGUI
    [SerializeField] private Transform canvasTransform;   // Where to spawn (usually your Canvas)

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

                // Spawn text
                SpawnEndMessage();
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void SpawnEndMessage()
    {
        if (endMessagePrefab != null && canvasTransform != null)
        {
            GameObject msg = Instantiate(endMessagePrefab, canvasTransform);
            msg.GetComponent<TextMeshProUGUI>().text = "Time’s Up!";
        }
    }
}
