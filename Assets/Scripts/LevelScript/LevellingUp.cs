using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevellingUp : ExperienceSystem
{
    public GameObject LevelupUI;
    private int previousLevel;
    // Start is called before the first frame update
    void Start()
    {
       previousLevel = GetLevelNumber();
        LevelupUI.SetActive(false);
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
}
