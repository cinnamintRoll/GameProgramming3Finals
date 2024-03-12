 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHP player = other.GetComponent<PlayerHP>();

        if (other.CompareTag("Player"))
        {
            player.TakeDamage(2);
            Destroy(gameObject);
        }
    }
}
