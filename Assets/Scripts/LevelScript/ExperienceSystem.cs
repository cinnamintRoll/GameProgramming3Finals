using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private int level;
    private int experience;
    private int experienceToNextLevel;

    public ExperienceSystem() {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            //if enough experience to level up
            level++;
            experience -= experienceToNextLevel;
            if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperienceNormalized()
    {
        return (float)experience / experienceToNextLevel;
    }
}
