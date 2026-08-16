using UnityEngine;   // Import Unity’s core library (needed for MonoBehaviour, GameObject, Transform, Vector3, etc.)

public class PathFollower : MonoBehaviour   // Define a class called PathFollower that inherits from MonoBehaviour (so it can be attached to a Unity GameObject)
{
    public Transform[] waypoints;   // Array of waypoints (empty GameObjects) that define the path. Assigned in the Inspector.
    public float speed = 5f;        // Movement speed of the object. Visible in the Inspector.
    private int currentIndex = 0;   // Tracks which waypoint the object is currently moving toward.

    void Update()                   // Unity’s Update() method runs every frame.
    {
        if (waypoints.Length == 0) return; 
        // Safety check: if no waypoints are assigned, exit early to avoid errors.

        Transform target = waypoints[currentIndex]; 
        // Get the current target waypoint based on the index.

        transform.position = Vector3.MoveTowards(
            transform.position,      // Current position of the object.
            target.position,         // Position of the target waypoint.
            speed * Time.deltaTime   // Distance to move this frame (speed multiplied by frame time).
        );
        // This moves the object smoothly toward the target waypoint.

        if (Vector3.Distance(transform.position, target.position) < 0.1f) 
        {
            // If the object is very close to the target waypoint (within 0.1 units)…
            currentIndex++;          // …move to the next waypoint in the array.

            if (currentIndex >= waypoints.Length) 
            {
                currentIndex = 0;    // If the end of the array is reached, loop back to the first waypoint.
            }
        }
    }
}
