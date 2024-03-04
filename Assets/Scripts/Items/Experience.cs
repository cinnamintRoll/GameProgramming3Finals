using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public int XP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelWindow levelWindow = FindObjectOfType<LevelWindow>(); // Find the LevelWindow script
            if (levelWindow != null)
            {
                levelWindow.AddExperience(XP); // Add 5 experience points
            }

            Destroy(gameObject);
        }
    }
}

