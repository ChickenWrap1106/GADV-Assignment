using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);

    }

}
// Goes to level select page