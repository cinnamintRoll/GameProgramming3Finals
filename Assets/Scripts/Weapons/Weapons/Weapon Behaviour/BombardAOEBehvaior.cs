using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardAOEBehvaior : BombardAOEController
{
    public float changeInterval;
    private Vector3 randomDirection;
    private float timer;

    protected override void Start()
    {
        ChangeDirection();
        Destroy(gameObject, duration);
    }

    protected override void Update()
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
        randomDirection = Random.insideUnitSphere * speed;
        randomDirection.y = 0; // Ensure movement is only on the XZ plane
    }

    private void Move()
    {
        transform.Translate(randomDirection * Time.deltaTime, Space.World);
    }
}
