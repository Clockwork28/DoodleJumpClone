using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public bool gameOver = false;
    public void EndGame()
    {
        Debug.Log("EndGame initiated");
        gameOver = true;
        gameOverUI.SetActive(true);
    }

    public void LoadNextScene()
    {

        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIdx = currentSceneIdx + 1;

        if (nextSceneIdx < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIdx);
        }
        else
        {
            Debug.Log("No more scenes to load");
            SceneManager.LoadScene(0);
        }
       
    }
}
