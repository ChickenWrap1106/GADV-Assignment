using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Needed for scene loading

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elements")]
    public TextMeshProUGUI counterText;

    [Header("Win Settings")]
    [SerializeField] private int winScore = 10; // Target score
    [SerializeField] private int winSceneIndex = 1; // Index of scene to load

    private int counter = 0;

    void Awake()
    {
        instance = this;
        counterText.text = "Score: 0";
    }

    public void AddPoint(int amount)
    {
        counter += amount;
        counterText.text = "Score: " + counter;

        if (counter >= winScore)
        {
            LoadWinScene();
        }
    }

    private void LoadWinScene()
    {
        SceneManager.LoadScene(winSceneIndex);
    }
}
