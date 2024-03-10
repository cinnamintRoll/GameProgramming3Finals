using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRadius = 8f;
    public float idleTime = 2f;

    public float damage = 5f;

    private Transform player;
    private SpriteRenderer sprite;
    private Rigidbody2D body;
    private Vector2 idlePosition;
    private bool isIdle = false;


    #region Movement
    private enum State
    {
        Idle,
        Chase
    }
    private State currentState;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
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

        if (direction.x < 0)
        {
            sprite.flipX = true; 
        }
        else
        {
            sprite.flipX = false; 
        }

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
    #endregion

    
}
