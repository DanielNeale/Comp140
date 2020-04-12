using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private int lives = 0;
    private int score;

    [SerializeField]
    private TextMeshProUGUI scoreText = null;
    [SerializeField]
    private TextMeshProUGUI livesText = null;


    void Start()
    {
        scoreText.text = ("Score: " + score);
        livesText.text = ("Lives: " + lives);
    }


    public void AddScore(int gainedScore)
    {
        score += gainedScore;
        scoreText.text = ("Score: " + score);
    }

    public void TakeLife()
    {
        lives -= 1;
        livesText.text = ("Lives: " + lives);

        if (lives <= 0)
        {

        }
    }
}
