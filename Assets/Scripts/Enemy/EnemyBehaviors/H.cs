using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H : MonoBehaviour
{
    public List<GameObject> objectsToThrow; 
    public float commentDamage = 20f;
    public float questionDamage = 30f;
    public float throwForce = 10f;
    public float throwCooldown = 3f;
    public float detectionRadius = 8f;
    public LayerMask playerLayer;
    public int numberOfThrows = 5;

    private Transform player;
    private float lastThrowTime;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player != null && objectsToThrow.Count > 0)
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
        List<GameObject> thrownObjects = new List<GameObject>(); 

        for (int i = 0; i < numberOfThrows; i++)
        {
            GameObject objectToThrow = objectsToThrow[Random.Range(0, objectsToThrow.Count)]; // Randomly select object to throw
            GameObject thrownObject = Instantiate(objectToThrow, transform.position, Quaternion.identity);

            if (thrownObject.GetComponent<Comments>() != null)
            {
                thrownObject.GetComponent<Comments>().damage = commentDamage;
            }
            else if (thrownObject.GetComponent<Questions>() != null)
            {
                thrownObject.GetComponent<Questions>().damage = questionDamage;
            }

            Vector2 direction = (player.position - transform.position).normalized;
            Rigidbody2D objectBody = thrownObject.GetComponent<Rigidbody2D>();

            if (objectBody != null)
            {
                Vector2 randomDirection = direction + (Random.insideUnitCircle.normalized * 0.2f);
                objectBody.velocity = randomDirection * throwForce;
            }

            thrownObjects.Add(thrownObject); 
        }

        StartCoroutine(DestroyObjectsAfterDelay(thrownObjects, 3f)); 
    }

    IEnumerator DestroyObjectsAfterDelay(List<GameObject> objects, float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
}
