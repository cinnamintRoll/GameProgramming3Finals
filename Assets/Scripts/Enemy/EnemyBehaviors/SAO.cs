using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAO : MonoBehaviour
{
    public GameObject objectToThrow;
    public float commentDamage = 10f;
    public Transform player;
    public float throwForce = 10f;
    public float throwCooldown = 3f;
    public float detectionRadius = 8f;
    public LayerMask playerLayer;
    public int numberOfThrows = 3;
    public float defeatTimeout = 15f;

    private float lastThrowTime;
    private bool hasBeenDefeated;


    void Start()
    {
        Invoke("Fail", defeatTimeout);    
    }

    void Update()
    {
        if (!hasBeenDefeated && player != null && objectToThrow != null)
        {
            if (CanThrow() && IsPlayerInRange())
            {
                Throw();
                lastThrowTime = Time.time;
            }
        }
    }

    bool CanThrow()
    {
        return Time.time - lastThrowTime >= throwCooldown;
    }

    bool IsPlayerInRange()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);
        foreach (Collider2D collider in colliders)
        {
            if (collider.transform == player)
            {
                return true;
            }
        }
        return false;
    }

    void Throw()
    {
        for (int i = 0; i < numberOfThrows; i++)
        {
            GameObject thrownObject = Instantiate(objectToThrow, transform.position, Quaternion.identity);
            thrownObject.GetComponent<Comments>().damage = commentDamage;
            Vector2 direction = (player.position - transform.position).normalized;
            Rigidbody2D objectBody = thrownObject.GetComponent<Rigidbody2D>();

            if (objectBody != null)
            {
                Vector2 randomDirection = direction + (Random.insideUnitCircle.normalized * 0.2f);
                objectBody.velocity = randomDirection * throwForce;
            }

            StartCoroutine(DestroyObjectAfterDelay(thrownObject, 3f));
        }
    }

    IEnumerator DestroyObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }

    void Fail()
    {
        if (!hasBeenDefeated)
        {
            Debug.Log("Player has failed to defeat enemy"); //Temp
        }
    }

    public void Defeated()
    {
        hasBeenDefeated = true;
        CancelInvoke("Fail");
    }
}
