using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ExperienceSystem ExperienceSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        //things left to add...(ye I got lazy) - Shayne
        // Handle enemy death (example, play death animation, spawn particles, etc.) no asset yet
        // ...

        // Add XP to the player
        ExperienceSystem.AddXP();
    }
}
