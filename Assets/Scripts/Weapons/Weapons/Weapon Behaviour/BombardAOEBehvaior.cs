using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardAOEBehvaior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float changeInterval;

    private Vector3 randomDirection;
    private float timer;
    public float destroyAfterSeconds;

    private void Start()
    {
        ChangeDirection();
        Destroy(gameObject, destroyAfterSeconds);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            ChangeDirection();
            timer = 0f;
        }

        Move();
    }

    private void ChangeDirection()
    {
        randomDirection = Random.insideUnitSphere * moveSpeed;
        randomDirection.y = 0; // Ensure movement is only on the XZ plane
    }

    private void Move()
    {
        transform.Translate(randomDirection * Time.deltaTime, Space.World);
    }
}
