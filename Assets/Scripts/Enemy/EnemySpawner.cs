using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyType
{
    public string typeName;
    public GameObject prefab;
    public float spawnRate;
}

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyType> enemyTypes;
    public float baseSpawnRate = 5f;
    public float spawnRadius = 5f;
    public float spawnRateMultiplier = 0.04f; // Multiplier to adjust spawn rate over time
    public float multiplierInterval = 30f; 
    public Transform playerTransform;
    public Vector2 playerOffset;
    public GameObject enemyContainer; // Reference to the container GameObject

    private float nextSpawnTime = 0f;
    private float nextMultiplierActivationTime = 0f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        enemyContainer = new GameObject("EnemyContainer"); // Create an empty GameObject for enemies
        nextMultiplierActivationTime = Time.time + multiplierInterval; // Set the initial activation time
    }

    void Update()
    {
        transform.position = (Vector2)playerTransform.position + playerOffset;

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            CalculateNextSpawnTime();
        }

        if (Time.time >= nextMultiplierActivationTime)
        {
            ActivateSpawnRateMultiplier();
        }
    }

    void SpawnEnemy()
    {
        EnemyType randomEnemyType = GetRandomEnemyType();
        if (randomEnemyType != null)
        {
            Vector2 randomPosition = GetRandomSpawnPosition();
            GameObject newEnemy = Instantiate(randomEnemyType.prefab, randomPosition, Quaternion.identity);
            newEnemy.transform.SetParent(enemyContainer.transform); // Set the parent of the spawned enemy to the container
        }
    }

    EnemyType GetRandomEnemyType()
    {
        if (enemyTypes.Count == 0)
        {
            Debug.Log("No enemy types defined.");
            return null;
        }

        float totalSpawnRate = 0f;
        foreach (EnemyType enemyType in enemyTypes)
        {
            totalSpawnRate += enemyType.spawnRate;
        }

        float randomValue = UnityEngine.Random.Range(0, totalSpawnRate);
        foreach (EnemyType enemyType in enemyTypes)
        {
            randomValue -= enemyType.spawnRate;
            if (randomValue <= 0f)
            {
                return enemyType;
            }
        }

        return null; // Not likely: to handle errors
    }

    Vector2 GetRandomSpawnPosition()
    {
        float randomAngle = UnityEngine.Random.Range(0f, Mathf.PI * 2f);
        float spawnX = transform.position.x + Mathf.Cos(randomAngle) * spawnRadius;
        float spawnY = transform.position.y + Mathf.Sin(randomAngle) * spawnRadius;
        return new Vector2(spawnX, spawnY);
    }

    void CalculateNextSpawnTime()
    {
        float spawnRate = baseSpawnRate * spawnRateMultiplier;
        nextSpawnTime = Time.time + 1f / spawnRate;
    }

    void ActivateSpawnRateMultiplier()
    {
        spawnRateMultiplier *= 2; 
        nextMultiplierActivationTime = Time.time + multiplierInterval; // Set the next activation time
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
