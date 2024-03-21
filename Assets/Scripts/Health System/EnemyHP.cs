using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HealthSystem
{

    
    public GameObject expPrefab;
    public int expValue = 5;

    protected override void Start()
    {
        base.Start();
    }


    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }

    protected override void Die()
    {
        base.Die();
        SpawnExperience();
        EnemyEventManager.Instance.TriggerEnemydeath();
        Debug.Log("Enemy death event triggered.");
        StartCoroutine(DisableAfterDelay());
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    private void SpawnExperience()
    {
        if (expPrefab != null)
        {
            GameObject expInstance = Instantiate(expPrefab, transform.position, Quaternion.identity);
            expInstance.GetComponent<Experience>().XP = expValue;
        }
        else
        {
            Debug.LogWarning("Experience prefab is not assigned to EnemyHP script.");
        }
    }

}
