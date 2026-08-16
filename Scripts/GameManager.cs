using UnityEngine;                 // Import Unity’s core library (needed for MonoBehaviour, GameObject, etc.)
using TMPro;                       // Import TextMeshPro library (needed for UI text elements)
using UnityEngine.SceneManagement; // Import SceneManagement (needed for loading new scenes)

public class GameManager : MonoBehaviour   // Define a class called GameManager that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    public static GameManager instance;    // Static reference to GameManager (singleton pattern). Allows other scripts to access GameManager easily.

    [Header("UI Elements")]                // Creates a header in the Unity Inspector to group related variables.
    public TextMeshProUGUI counterText;    // Reference to the UI text element that displays the player’s score.

    [Header("Win Settings")]               // Another header in the Inspector for win-related settings.
    [SerializeField] private int winScore = 10;       // Target score required to win the game. Editable in Inspector.
    [SerializeField] private int winSceneIndex = 1;   // Index of the scene to load when the player wins. Set in Build Settings.

    private int counter = 0;               // Tracks the current score of the player.

    void Awake()                           // Unity’s Awake() method runs before Start(), used for initialization.
    {
        instance = this;                   // Assign this GameManager instance to the static reference (singleton setup).
        counterText.text = "Score: 0";     // Initialize the score display at the start of the game.
    }

    public void AddPoint(int amount)       // Public method to add points to the player’s score. Called by Item.cs when items are collected.
    {
        counter += amount;                 // Increase the score by the given amount.
        counterText.text = "Score: " + counter; // Update the UI text to show the new score.

        if (counter >= winScore)           // Check if the player’s score has reached or exceeded the win condition.
        {
            LoadWinScene();                // If so, load the win scene.
        }
    }

    private void LoadWinScene()            // Private method to handle scene transition when the player wins.
    {
        SceneManager.LoadScene(winSceneIndex); 
        // Load the scene at the specified index from Build Settings.
        // This replaces the current scene with the win scene.
    }
}
