using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    PauseMenu pauseMenu;
    public static scoreManager instance;

    public Text scoreText;
    public Text highScoreText;
    public Text gameOver;
    
    int score = 0;
    int highScore = 0;

    private void Awake ( ) 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();
        highScore = PlayerPrefs.GetInt("highscore",0);
        scoreText.text = score.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }
    public void Update ()
    {
        
    }

    public void AddPoint()
    {
        score += 50;
        scoreText.text = score.ToString() + " POINTS";
        if ( highScore < score )
            PlayerPrefs.SetInt("highscore", score);
        if (score < highScore)
        {
            highScore = score;
        }
    }
    public void AddPointAtOnce()
    {
        score += 100;
        scoreText.text = score.ToString() + " POINTS";
        if (highScore < score)
            PlayerPrefs.SetInt("highscore", score);
        if (score < highScore)
        {
            highScore = score;
        }
        // highScoreText.text = "HIGHSCORE: " + score.ToString();
    }


    public void GameOver()
    {
        gameOver.text = "Game Over!";
        PauseMenu.instance.Pause();
        PauseMenu.instance.restartGame();
        Debug.Log("Game Over");
    }


}
