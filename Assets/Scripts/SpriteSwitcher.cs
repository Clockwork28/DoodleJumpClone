using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.relativeVelocity.y <= 1f)
        {
            spriteRenderer.sprite = sprite2;
        }
    }

    public void ResetSprite()
    {
        spriteRenderer.sprite = sprite1;
    }
}
