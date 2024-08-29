using System.Collections;
using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    [SerializeField] float fallSpeed = 8f;
    public bool broken = false;
    [SerializeField] AudioClip sfx;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
    }

    private void Update()
    {
        if (broken)
        {
            float newY = transform.position.y + fallSpeed * -1 * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, newY);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player") && collision.relativeVelocity.y <= 1f)
        {
            SoundFXManager.instance.PlaySFX(sfx, 1f);
            StartCoroutine(Wait(1.3f));
            Collider2D playerCollider = collision.gameObject.GetComponent<Collider2D>();
            Collider2D objectCollider = GetComponent<EdgeCollider2D>();
            Physics2D.IgnoreCollision(objectCollider, playerCollider);
            broken = true;
            StartCoroutine(RestartCollision(objectCollider, playerCollider));
        }
    }

    IEnumerator RestartCollision(Collider2D objectCollider, Collider2D playerCollider)
    {

        yield return new WaitForSeconds(1.2f);
        Physics2D.IgnoreCollision(objectCollider, playerCollider, false);
        broken = false;
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
