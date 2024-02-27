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
    public float spawnRateMultiplier = 1f; //Multiplier to adjust spawn rate over time
    public Vector2 playerOffset;

    private float nextSpawnTime = 0f;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = (Vector2)playerTransform.position + playerOffset;
        
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            CalculateNextSpawnTime();
        }
    }

    void SpawnEnemy()
    {
        EnemyType randomEnemyType = GetRandomEnemyType();
        if (randomEnemyType != null)
        {
            Vector2 randomPosition = GetRandomSpawnPosition();
            Instantiate(randomEnemyType.prefab, randomPosition, Quaternion.identity);
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
            if(randomValue <= 0f)
            {
                return enemyType;
            }
        }

        return null; //not likely: to handle errors
    }

    Vector2 GetRandomSpawnPosition()
    {
        float randomAngle = UnityEngine.Random.Range(0f, Mathf.PI * 2f);
        float spawnX = transform.position.x + Mathf.Cos(randomAngle) + spawnRadius;
        float spawnY = transform.position.y + Mathf.Cos(randomAngle) + spawnRadius;
        return new Vector2(spawnX, spawnY);
    }

    void CalculateNextSpawnTime()
    {
        float spawnRate = baseSpawnRate * spawnRateMultiplier;
        nextSpawnTime = Time.time + 1f / spawnRate;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
