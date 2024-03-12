using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentAbomination : MonoBehaviour
{
    public GameObject miniAssignments;
    public float spawnDistance = 1f;

    private void OnEnable()
    {
        Debug.Log("AssignmentAbomination enabled.");
        EnemyEventManager.OnEnemyDeath += SpawnMiniAssignments;
        Debug.Log("SpawnMiniAssignments subscribed to OnEnemyDeath event.");
    }

    private void OnDisable()
    {
        Debug.Log("AssignmentAbomination disabled.");
        EnemyEventManager.OnEnemyDeath -= SpawnMiniAssignments;
    }

    public void SpawnMiniAssignments()
    {
        /*Debug.Log("SpawnMiniAssignments() method called.");
        Instantiate(miniAssignments, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("spawned prefab");*/

        Vector3 spawnPosition = transform.position;
        Debug.Log("Spawn Position: " + spawnPosition);
        for (int i = 0; i < 4; i++)
        {
            Instantiate(miniAssignments, spawnPosition, Quaternion.identity);
            spawnPosition += new Vector3(spawnDistance, 0, spawnDistance);
            if (i == 1)
            {
                spawnPosition -= new Vector3(spawnDistance * 2, 0, 0);
            }
        }
    }

}
