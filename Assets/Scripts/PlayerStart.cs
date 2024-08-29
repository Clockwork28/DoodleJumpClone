using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    [SerializeField] float initialJumpForce = 15f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.linearVelocity;
        velocity.y = initialJumpForce;
        rb.linearVelocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
