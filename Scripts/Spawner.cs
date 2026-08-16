using UnityEngine;   // Import Unity’s core library (needed for MonoBehaviour, GameObject, Collider2D, etc.)

public class Spawner : MonoBehaviour   // Define a class called Spawner that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    [Header("Spawning Settings")]       // Creates a header in the Unity Inspector to group related variables.
    public GameObject itemPrefab;       // The prefab (template object) that will be spawned. Assigned in the Inspector.
    public float spawnInterval = 5f;    // Time in seconds between each spawn cycle.

    private BoxCollider2D spawnArea;    // Reference to the BoxCollider2D that defines the spawn area boundaries.
    private float nextSpawnTime;        // Tracks the next time an item should be spawned.

    void Awake()                        // Unity’s Awake() method runs before Start(), used for initialization.
    {
        spawnArea = GetComponent<BoxCollider2D>(); // Get the BoxCollider2D component attached to this GameObject.
        // This collider defines the rectangular area where items can appear.
    }

    void Update()                       // Unity’s Update() method runs every frame.
    {
        // Check if the current game time has reached or passed the next scheduled spawn time.
        if (Time.time >= nextSpawnTime)
        {
            SpawnItem();                // Call the method to spawn a new item.
            nextSpawnTime = Time.time + spawnInterval; 
            // Reset the next spawn time by adding the interval to the current time.
        }
    }

    void SpawnItem()                    // Method that handles the actual spawning of items.
    {
        if (itemPrefab == null || spawnArea == null) return; 
        // Safety check: if no prefab or spawn area is assigned, exit early.

        Bounds bounds = spawnArea.bounds; 
        // Get the absolute boundaries (min/max X and Y) of the BoxCollider2D.

        // Pick a random X and Y coordinate within those boundaries.
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f); 
        // Create the final spawn position vector. Z is fixed at 0 for 2D games.

        Instantiate(itemPrefab, spawnPosition, Quaternion.identity); 
        // Instantiate (create) the item prefab at the chosen position with no rotation.
    }
}
