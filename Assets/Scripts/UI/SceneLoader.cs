using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /*public GameObject MainMenu;
    public GameObject UI;
    public GameObject Gameover;
    public void Start()
    {
        MainMenu.SetActive(true);
        UI.SetActive(false);
        Gameover.SetActive(false);
        Time.timeScale = 0f;
        SceneManager.LoadScene("Game");
    }
    public void Update()
    {
        
    }*/


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); 
    }
    public void LoadGameScene()
    {
        //MainMenu.SetActive(false);
        //UI.SetActive(true);
        //Gameover.SetActive(false);
        //Time.timeScale = 1f;
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
