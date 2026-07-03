using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float slowSpeed = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = other.GetComponent<PlayerCtrl>();

        if (player != null)
        {
            player.moveSpeed = slowSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerCtrl player = other.GetComponent<PlayerCtrl>();

        if (player != null)
        {
            player.moveSpeed = player.defaultSpeed;
        }
    }
}