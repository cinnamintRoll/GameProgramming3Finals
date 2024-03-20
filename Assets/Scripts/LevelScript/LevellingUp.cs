using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevellingUp : ExperienceSystem
{
    public GameObject LevelupUI;
    private int previousLevel;

    public Button option1;
    public Button option2;
    public Button option3;

    // Start is called before the first frame update
    void Start()
    {
       previousLevel = GetLevelNumber();
        LevelupUI.SetActive(false);

        /*option1.onClick.AddListener(CloseOptions);
        option2.onClick.AddListener(CloseOptions);
        option3.onClick.AddListener(CloseOptions);*/
    }

    // Update is called once per frame
    void Update()
    {
        checkLevel();
    }

    private void checkLevel()
    {
        
        int currentLevel = GetLevelNumber();;
        if (currentLevel > previousLevel)
        {

            previousLevel = currentLevel;
        }
    }
    private void UILevelup()
    {

        LevelupUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseOptions()
    {
        LevelupUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
}
