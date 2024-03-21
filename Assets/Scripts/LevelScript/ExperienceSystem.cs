using System;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private int level;
    private int experience;
    private int experienceToNextLevel;
    //public int XpMultiplier;

    private Inventory playerInventory;

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
        //playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic goes here
    }

    public void AddExperience(int amount)
    {

        /*int Xpcalculated = (XpMultiplier * amount) + amount;
        int itemIDToCheck = 13; // Replace 123 with the actual item ID you want to check
        bool itemExists = playerInventory.CheckItem(itemIDToCheck);

        if (itemExists)
        {
            experience += Xpcalculated;
        }
        else
        {
            experience += amount;
        }

        if (experience >= experienceToNextLevel)
        {
            //if enough experience to level up
            level++;
            experience -= experienceToNextLevel;
            if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);*/

        experience += amount;
        if(experience >= experienceToNextLevel)
        {
            level++;
            experience -= experienceToNextLevel;
            if(OnLevelChanged != null)  OnLevelChanged(this, EventArgs.Empty);

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
