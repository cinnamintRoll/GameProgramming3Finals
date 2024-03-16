using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comments : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHP player = other.GetComponent<PlayerHP>();

        if (other.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
