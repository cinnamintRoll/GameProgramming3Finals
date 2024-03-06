using System;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private int level;
    private int experience;
    private int experienceToNextLevel;

    // Use Awake for initialization
    void Awake()
    {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }

    void Start()
    {
        // Your additional initialization code goes here
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic goes here
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
