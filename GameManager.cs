using UnityEngine;
using TMPro; // if using TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI counterText;
    private int counter = 0;

    void Awake()
    {
        instance = this;
        counterText.text = "Score: ";
    }

    public void AddPoint()
    {
        counter++;
        counterText.text = "Score: " + counter;
    }
}
