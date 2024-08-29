using Unity.VisualScripting;
using UnityEngine;

public class Platform_AddScore : MonoBehaviour
{

    public Score scoreScript;
    bool hasTriggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasTriggered)
        {
            GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");
            hasTriggered = true;
            scoreScript = scoreTextObject.GetComponent<Score>();
            scoreScript.score++;
        }
    }
}
