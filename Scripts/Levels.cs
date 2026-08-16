using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
     public void OpenLevel(int levelId)
     {
          string levelName = "Level " + levelId;
          SceneManager.LoadScene(levelName); 

     }
}
// loads the level id from the build profile