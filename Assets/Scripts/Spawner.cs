using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to spawn
    public Vector3 spawnOffset = Vector3.zero; // Offset for the spawn location
    public float spawnInterval = 10.0f; // Time between spawns
    public Vector3 spawnRotation = Vector3.zero; // Rotation for the spawn location

    private List<GameObject> spawnedPrefabs = new List<GameObject>(); // List to store spawned prefabs

    private void Start()
    {
        // Start the repetitive spawning every `spawnInterval` seconds
        StartSpawning();
    }

    private void StartSpawning()
    {
        // Cancel any existing invokes
        CancelInvoke("SpawnPrefab");

        // Start invoking SpawnPrefab with the new spawn interval
        InvokeRepeating("SpawnPrefab", spawnInterval, spawnInterval);
    }

    private void SpawnPrefab()
    {
        // Determine the spawn position
        Vector3 spawnPosition = transform.position + spawnOffset;

        // Create the rotation from the spawnRotation vector
        Quaternion rotation = Quaternion.Euler(spawnRotation);

        // Instantiate the prefab at the specified position and rotation
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, rotation);

        // Add the spawned prefab to the list
        spawnedPrefabs.Add(spawnedObject);
    }

    // Reset the spawner
    public void ResetSpawner()
    {
        // Destroy all spawned prefabs
        foreach (GameObject prefab in spawnedPrefabs)
        {
            Destroy(prefab);
        }

        // Clear the list of spawned prefabs
        spawnedPrefabs.Clear();

        // Restart spawning
        StartSpawning();
    }

    // Stop invoking when the GameObject is disabled or destroyed
    private void OnDestroy()
    {
        CancelInvoke("SpawnPrefab");
    }
}
