using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [System.Serializable]
    public class PropPrefabWeight
    {
        public GameObject prefab;
        public int weight;
    }

    public List<GameObject> propSpawnPoints;
    public List<PropPrefabWeight> propPrefabs;

    void Start()
    {
        SpawnProps();
    }

    void SpawnProps()
    {
        // Create a list to hold all possible prefabs based on their weights
        List<GameObject> weightedPrefabs = new List<GameObject>();

        // Populate the weighted prefabs list according to the weights
        foreach (var prop in propPrefabs)
        {
            for (int i = 0; i < prop.weight; i++)
            {
                weightedPrefabs.Add(prop.prefab);
            }
        }

        // Spawn a random prop at every spawn point
        foreach (GameObject sp in propSpawnPoints)
        {
            // Choose a random index from the weighted prefabs list
            int randIndex = Random.Range(0, weightedPrefabs.Count);

            // Instantiate the selected prefab
            GameObject prop = Instantiate(weightedPrefabs[randIndex], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;  // Move spawned object into spawn point

            // Remove the selected prefab from the list to avoid spawning it again
            weightedPrefabs.RemoveAt(randIndex);
        }
    }
}
