using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepDeprivationSpecter : MonoBehaviour
{
    public float slowFactor = 0.35f;
    public float slowDuration = 3f;
    public float cooldownIncrease = 2f;

    private PlayerMovement playerMovement;
    private WeaponController[] weaponControllers;
    private bool isPlayerSlowed = false;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Collision detected");

            playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (!isPlayerSlowed && playerMovement != null)
            {
                playerMovement.ApplySlowDebuff(slowFactor);

                weaponControllers = other.gameObject.GetComponentsInChildren<WeaponController>();
                foreach (WeaponController weapon in weaponControllers)
                {
                    if (!isPlayerSlowed)
                    {
                        weapon.CooldownDebuff(cooldownIncrease);
                    }
                }

                isPlayerSlowed = true;

                Invoke("RevertSpeed", slowDuration);
            }
        }
    }

    private void RevertSpeed()
    {
        //Debug.Log("RevertSpeed invoked");
        if (playerMovement != null && weaponControllers != null)
        {
            foreach (WeaponController weapon in weaponControllers)
            {
                weapon.ResetCooldown();
            }

            playerMovement.ResetSpeed();

            isPlayerSlowed = false;
        }
    }
}
