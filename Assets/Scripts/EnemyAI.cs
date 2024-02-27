using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRadius = 8f;
    public float idleTime = 2f;

    private Transform player;
    private Rigidbody2D body;
    private Vector2 idlePosition;
    private bool isIdle = false;

    private enum State
    {
        Idle,
        Chase
    }
    private State currentState;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        body = GetComponent<Rigidbody2D>();
        currentState = State.Idle;
        idlePosition = transform.position;
    }

    void Update()
    {
        if (currentState == State.Idle)
        {
            IdleState();
        }
        else if (currentState == State.Chase)
        {
            ChaseState();
        }
    }

    

    void IdleState()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            currentState = State.Chase;
            return;
        }

        if (!isIdle)
        {
            isIdle = true;
            Invoke("ReturnToIdle", idleTime);
        }
    }

    void ReturnToIdle()
    {
        currentState = State.Idle;
        isIdle = false;
    }
    void ChaseState()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        body.velocity = direction * moveSpeed;

        if (Vector2.Distance(transform.position, player.position) > detectionRadius)
        {
            currentState = State.Idle;
        }
    }

    /*void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }*/
}
