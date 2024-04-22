using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to spawn
    public Vector3 spawnOffset = Vector3.zero; // Offset for the spawn location
    public float spawnInterval = 10.0f; // Time between spawns
    public Vector3 spawnRotation = Vector3.zero; // Rotation for the spawn location

    private void Start()
    {
        // Start the repetitive spawning every `spawnInterval` seconds
        InvokeRepeating("SpawnPrefab", spawnInterval, spawnInterval);
    }

    private void SpawnPrefab()
    {
        // Determine the spawn position
        Vector3 spawnPosition = transform.position + spawnOffset;

        // Create the rotation from the spawnRotation vector
        Quaternion rotation = Quaternion.Euler(spawnRotation);

        // Instantiate the prefab at the specified position and rotation
        Instantiate(prefabToSpawn, spawnPosition, rotation);
    }

    // Stop invoking when the GameObject is disabled or destroyed
    private void OnDestroy()
    {
        CancelInvoke("SpawnPrefab");
    }
}
