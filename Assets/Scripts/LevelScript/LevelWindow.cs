using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelWindow : MonoBehaviour
{
    private Text levelText;
    private Image experienceBarImage;
    private ExperienceSystem experienceSystem;
    public Button experience5Btn; // Drag your button here in the Inspector


    private void Awake()
    {
        levelText = transform.Find("levelText").GetComponent<Text>();
        experienceBarImage = transform.Find("experienceBar").Find("bar").GetComponent<Image>();
    }
    private void SetExperienceBarSize(float experienceNormalized)
    {
    experienceBarImage.fillAmount = experienceNormalized;
    }
    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "LEVEL\n" + (levelNumber + 1);
    }
    public void SetExperienceSystem(ExperienceSystem experienceSystem)
    {
        this.experienceSystem = experienceSystem;

        SetLevelNumber(experienceSystem.GetLevelNumber());
        SetExperienceBarSize(experienceSystem.GetExperienceNormalized());

        experienceSystem.OnExperienceChanged += ExperienceSystem_OnExperienceChanged;
        experienceSystem.OnLevelChanged += ExperienceSystem_OnLevelChanged;
    }
    private void ExperienceSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        SetLevelNumber(experienceSystem.GetLevelNumber());
    }
    private void ExperienceSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        SetExperienceBarSize(experienceSystem.GetExperienceNormalized());
    }
    public void AddExperienceOnClick()
    {
        // Add 5 experience points
        experienceSystem.AddExperience(5);
    }
}
