using Unity.VisualScripting;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] LevelGenerator levelGenerator;
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"Name of collision: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.movementSpeed = 0f;
            gameManager = FindAnyObjectByType<GameManager>();
            gameManager.EndGame();
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            levelGenerator.RecyclePlatforms(collision.gameObject);
        }
    }
}

