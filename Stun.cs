using UnityEngine;

public class Stun : MonoBehaviour
{
    public float stunDuration = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerCtrl player = collision.gameObject.GetComponent<PlayerCtrl>();

        if (player != null)
        {
            player.Stun(stunDuration);
        }
    }
}