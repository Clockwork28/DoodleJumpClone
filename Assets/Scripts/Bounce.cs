using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float jumpForce = 10f;
    [SerializeField] AudioClip sfx;
    [SerializeField] SoundFXManager sfxManager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.relativeVelocity.y <= 1f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                sfxManager = GameObject.Find("SoundFXManager").GetComponent<SoundFXManager>();
                sfxManager.PlaySFX(sfx, 1f);
                Vector2 velocity = rb.linearVelocity;
                velocity.y = jumpForce;
                rb.linearVelocity = velocity;

            }
        }
       
        
    }
}
