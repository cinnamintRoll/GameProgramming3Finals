using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBehavior : BoomerangController
{
    public float returnSpeedMultiplier = 2f;
    public float maxDistance = 20f;
    private Transform target;
    private Vector3 direction;
    private Vector3 initialPosition;
    private bool returning = false;
    private int enemiesPassed = 0;

    protected override void Start()
    {
        initialPosition = transform.position;
        FindNearestEnemy();
    }

    protected override void Update()
    {
        if (!returning)
        {
            if (target != null)
            {
                direction = (target.position - transform.position).normalized;
                transform.Translate(direction * speed * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, target.position) <= 0.1f)
                {
                    enemiesPassed++;
                    if (enemiesPassed >= pierce)
                    {
                        returning = true;
                    }
                    else
                    {
                        FindNearestEnemy();
                    }
                }
            }
            else
            {
                FindNearestEnemy();
            }
        }
        else
        {
            transform.Translate((initialPosition - transform.position).normalized * speed * returnSpeedMultiplier * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, initialPosition) <= 0.1f)
            {
                Destroy(gameObject);
            }
        }

        // Check if projectile has traveled beyond maximum distance
        if (Vector3.Distance(transform.position, initialPosition) >= maxDistance)
        {
            returning = true;
        }
    }

    private void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
    }
}
