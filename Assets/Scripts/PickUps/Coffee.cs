using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public float healAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHP player = other.GetComponent<PlayerHP>();

        if (other.CompareTag("Player"))
        {
            player.TakeDamage(healAmount);
            Destroy(gameObject);
        }
    }
}
