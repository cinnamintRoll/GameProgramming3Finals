using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextbookTerrors : MonoBehaviour
{
    public GameObject objectToThrow;
    public Transform player;
    public float throwForce = 10f;
    public float throwCooldown = 3f;
    public float detectionRadius = 8f;
    public LayerMask playerLayer;

    private float lastThrowTime;

    void Update()
    {
      if (player  != null && objectToThrow != null) 
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
        GameObject thrownObject = Instantiate(objectToThrow, transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;
        Rigidbody2D objectBody = thrownObject.GetComponent<Rigidbody2D>();

        if (objectBody != null)
        {
            objectBody.velocity = direction * throwForce;
        }

        StartCoroutine(DestroyObjectAfterDelay(thrownObject, 3f));
    }

    IEnumerator DestroyObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
