using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject itemPrefab; // The item you want to spawn
    public float spawnInterval = 2f; // Time between spawns

    private BoxCollider2D spawnArea;
    private float nextSpawnTime;

    void Awake()
    {
        // Get the BoxCollider2D component attached to this GameObject
        spawnArea = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Check if it is time to spawn a new item
        if (Time.time >= nextSpawnTime)
        {
            SpawnItem();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnItem()
    {
        if (itemPrefab == null || spawnArea == null) return;

        // Get the absolute boundaries of the BoxCollider2D
        Bounds bounds = spawnArea.bounds;

        // Pick a random X and Y coordinate within those boundaries
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        // Create the final position vector (Z remains 0 for 2D)
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        // Instantiate the item prefab at the random position
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
    }
}
