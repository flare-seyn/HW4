using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFlap : MonoBehaviour
{
    [SerializeField] private float flapForce = 6f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * flapForce;
        }
    }
}
