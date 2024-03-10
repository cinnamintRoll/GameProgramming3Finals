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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TempDMG"))
        {
            TakeDamage(1);
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
