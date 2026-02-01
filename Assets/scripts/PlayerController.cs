using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static event Action Flapped;
    public static event Action HitPipe;
    public static event Action Scored;

    [SerializeField] private float flapVelocity = 6f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameController.IsGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, flapVelocity);
            Flapped?.Invoke();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameController.IsGameOver) return;

        if (collision.collider.CompareTag("Pipe"))
        {
            HitPipe?.Invoke();
            GameController.TriggerGameOver();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameController.IsGameOver) return;

        if (other.CompareTag("ScoreZone"))
        {
            Scored?.Invoke();
        }
    }
}
