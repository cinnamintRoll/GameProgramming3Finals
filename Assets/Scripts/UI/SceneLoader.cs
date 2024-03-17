using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); 
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Game Exited");
    }
}
