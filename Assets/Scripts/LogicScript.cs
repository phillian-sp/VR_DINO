using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{

    public int playerScore = 0;
    public int highscore = 0;
    public bool isGameOver = false;

    public TextMeshPro scoreText;
    public TextMeshPro highscoreText;

    public GameObject gameOverScreen;
    public ObstacleSpawnScript objectSpawner;

    [ContextMenu("Increase Score")]

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = playerScore.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        highscoreText.text += "\n" + "SPEED: " + objectSpawner.speed.ToString();
        objectSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawnScript>();
    }

    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString() + " POINTS";
        if (highscore < playerScore)
        {
            PlayerPrefs.SetInt("highscore", playerScore);
            highscore = playerScore;
        }
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        highscoreText.text += "\n" + "SPEED: " + objectSpawner.speed.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {

        gameOverScreen.SetActive(true);
        isGameOver = true;
    }
}
