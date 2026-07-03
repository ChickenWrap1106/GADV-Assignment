using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 1f; 
    public float moveLimit = 3f;   

    private Vector3 startPos;
    private int direction = 1;       

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
  
        
            // Move up and down
            transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

            // Check if object needs to change direction
            if (Mathf.Abs(transform.position.x - startPos.x) >= moveLimit)
            {
                direction *= -1; 
            }
        
    }

}
