using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBehavior : MonoBehaviour
{
    public float speed = 5f; 
    private Transform enemy; 
    private Vector2 targetDirection;
    public float destroyAfterSeconds;

    private void Start()
    {
        // Find the enemy GameObject and get its transform
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        Destroy(gameObject, destroyAfterSeconds);
        targetDirection = (enemy.position - transform.position).normalized;
    }

    private void Update()
    {
        
        transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
    }

}
