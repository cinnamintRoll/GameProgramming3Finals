using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAOEProjectileBehavior : MonoBehaviour
{
    public float throwForceUpwards = 10f;
    public float throwForceForward = 5f;
    public float detectionRadius = 10f;

    private Rigidbody2D rb;
    private GameObject nearestEnemy;
    private bool hasLanded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Throw the projectile upwards and slightly forward
        if (rb != null)
        {
            Vector2 throwDirection = transform.up + transform.right.normalized * 0.5f; // Adjust the forward direction here
            rb.AddForce(throwDirection * throwForceUpwards, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        // If the projectile has landed and an enemy is nearby, start moving towards it
        if (hasLanded && nearestEnemy != null && rb != null)
        {
            Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;
            rb.velocity = direction * throwForceForward;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasLanded)
        {
            // Projectile has landed, find the nearest enemy
            hasLanded = true;
            rb.velocity = Vector2.zero; // Stop the projectile
            rb.gravityScale = 1; // Enable gravity
            FindNearestEnemy();
        }
    }

    void FindNearestEnemy()
    {
        // Find all game objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Initialize variables to store the closest enemy and its distance
        nearestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // Loop through each enemy to find the nearest one
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                nearestEnemy = enemy;
                closestDistance = distanceToEnemy;
            }
        }
    }
}




