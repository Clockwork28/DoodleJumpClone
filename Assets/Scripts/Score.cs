using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScore;
    public int score = 0;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            scoreText.text = score.ToString();
            gameOverScore.text = scoreText.text;
        }

    }
}
