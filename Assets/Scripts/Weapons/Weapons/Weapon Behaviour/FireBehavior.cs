using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : FireController
{
    private Transform enemy;
    public float destroyAfterSeconds;
    // Start is called before the first frame update
    protected override void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    protected override void Update()
    {
        Vector3 direction = (enemy.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;    //Set the movement of the Pen
    }
}
