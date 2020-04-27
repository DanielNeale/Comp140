using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int lives;
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
        Reset();
    }


    /// <summary>
    /// Adds a number to the score
    /// </summary>
    /// <param name="gainedScore"></param>
    /// The amount of score to add
    public void AddScore(int gainedScore)
    {
        score += gainedScore;
        scoreText.text = ("Score: " + score);
    }


    /// <summary>
    /// Removes a life and ends the game if lives go to zero
    /// </summary>
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


    /// <summary>
    /// Starts trains spawning and opens game UI
    /// </summary>
    public void StartGame()
    {
        gameObject.GetComponent<SpawnTrains>().setSpawn(true);
        SetUI(1);
    }


    /// <summary>
    /// Resets variables and opens start UI
    /// </summary>
    public void Reset()
    {
        SetUI(0);
        lives = 3;
        score = 0;
        scoreText.text = ("Score: " + score);
        livesText.text = ("Lives: " + lives);
    }


    /// <summary>
    /// Closes all UI and opens the one specified
    /// </summary>
    /// <param name="UI"></param>
    /// The UI that needs to be opened
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
