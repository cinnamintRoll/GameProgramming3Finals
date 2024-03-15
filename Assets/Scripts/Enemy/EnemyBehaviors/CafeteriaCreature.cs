using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeteriaCreature : MonoBehaviour
{
    public float healAmount = 0.2f;
    public float damageAmount = 1f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHP player = other.gameObject.GetComponent<PlayerHP>();

        if (other.gameObject.CompareTag("Player") && player != null)
        {
            float poisonChance = 0.1f; // 10% chance of player being poisoned. 
            float randomValue = Random.value;

            if (randomValue <= poisonChance)
            {
                player.TakeDamage(damageAmount);
            }
            else
            {
                player.Heal(healAmount);
            }
        }
    }
}
