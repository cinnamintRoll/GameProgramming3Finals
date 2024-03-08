using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAOEProjectileBehavior : MonoBehaviour
{
    public float speed = 5f;
    private Transform enemy;
    private Vector2 targetDirection;
    public float destroyAfterSeconds;
    public GameObject ThrowAOE;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        Destroy(gameObject, destroyAfterSeconds);
        targetDirection = (enemy.position - transform.position).normalized;
    }

    private void Update()
    {
        transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(ThrowAOE, collision.contacts[0].point, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}




