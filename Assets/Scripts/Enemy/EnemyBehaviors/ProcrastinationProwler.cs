using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcrastinationProwler : MonoBehaviour
{
    public float slowFactor = 0.5f; 
    public float slowDuration = 1f;

    private PlayerMovement playerMovement;
    private bool isPlayerSlowed = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPlayerSlowed)
        {
            playerMovement = other.gameObject.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.ApplySlowDebuff(slowFactor);
                Invoke("RevertSpeed", slowDuration);
                isPlayerSlowed = true;
            }
        }
    }

    private void RevertSpeed()
    {
        if (playerMovement != null)
        {
            playerMovement.ResetSpeed();
            isPlayerSlowed = false;
        }
    }
}
