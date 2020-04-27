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
    [SerializeField]
    private TextMeshProUGUI endScoreText = null;

    [SerializeField]
    private GameObject startUI = null;
    [SerializeField]
    private GameObject gameUI = null;
    [SerializeField]
    private GameObject endUI = null;


    void Start()
    {
        scoreText.text = ("Score: " + score);
        livesText.text = ("Lives: " + lives);

        startUI.SetActive(true);
        gameUI.SetActive(false);
        endUI.SetActive(false);
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
            endScoreText.text = ("Score: " + score);
            gameObject.GetComponent<SpawnTrains>().setSpawn(false);
            SetUI(2);
        }
    }


    public void StartGame()
    {
        gameObject.GetComponent<SpawnTrains>().setSpawn(true);
        SetUI(1);
    }


    public void Reset()
    {
        SetUI(0);
        lives = 3;
        score = 0;
        scoreText.text = ("Score: " + score);
        livesText.text = ("Lives: " + lives);
    }


    void SetUI(int UI)
    {
        startUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(false);

        if (UI == 0)
        {
            startUI.SetActive(true);
        }

        else if (UI == 1)
        {
            gameUI.SetActive(true);
        }

        else if (UI == 2)
        {
            endUI.SetActive(true);
        }
    }
}
