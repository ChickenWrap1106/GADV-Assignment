using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10f;

    [HideInInspector]
    public float defaultSpeed;

    private Rigidbody2D rb;
    private float speedX;
    private float speedY;

    private bool isStunned = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultSpeed = moveSpeed;
    }

    void Update()
    {
        if (isStunned)
        {
            speedX = 0;
            speedY = 0;
            return;
        }

        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (isStunned)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity = new Vector2(speedX * moveSpeed, speedY * moveSpeed);
        }
    }

    public void Stun(float duration)
    {
        StartCoroutine(StunCoroutine(duration));
    }

    IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;
        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(duration);

        isStunned = false;
    }
}