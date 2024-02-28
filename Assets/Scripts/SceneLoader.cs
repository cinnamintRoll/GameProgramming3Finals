using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1); 
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene(2); 
    }

    public void QuitGame()
    {
        Debug.Log("Game Exited");
    }
}
