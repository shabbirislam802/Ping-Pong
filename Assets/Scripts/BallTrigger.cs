using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallTrigger : MonoBehaviour
{
    public int score;
    public float waitTime = 1f;
    public TextMeshPro scoreText;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Hit");
            Destroy(other.gameObject);
            IncreaseScoreText();

            if (score < 99)
            {
                StartCoroutine(SpawnBall());
            }
            else
            {
                EndGame();
            }
    }

    void IncreaseScoreText()
    {
        score = Mathf.Clamp(score + 1, 0, 99);
        scoreText.text = score.ToString("D2");
    }

    IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(waitTime);
        gameManager.InitBallSpawnPosition();
    }

    void EndGame()
    {
        var player = (gameObject.name == "GoalRight") ? "Player right" : "Player left";
        Debug.Log("Spiel beendet. Gewinner: " + player + " mit " + score + " Punkten.");
    }
}
