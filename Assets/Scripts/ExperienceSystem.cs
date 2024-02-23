using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    public int totalXP = 0;
    public int xpPerKill = 10; // Adjust if needed
    public TextMeshProUGUI xpText; // Reference to the UI Text component
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this method when an enemy is defeated
    public void AddXP()
    {
        totalXP += xpPerKill;
        UpdateXPText();
    }

    //for the text (note by Shayne) $ = string interpolation like string sorta
    void UpdateXPText()
    {
        xpText.text = $"XP: {totalXP}";
    }
}
