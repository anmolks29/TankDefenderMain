using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public GameObject pauseMenuUI;
    public GameObject reStart;
    public GameObject gameOverBackDrop; 
    public GameObject pauseButton;
    public GameObject resusmeButton;


    public static PauseMenu instance;
    private void Start()
    {
        instance = this;
    }
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && pauseButton.activeInHierarchy == false  && resusmeButton.activeInHierarchy == true)
            {
                Resume();
                pauseButton.SetActive(true);
                resusmeButton.SetActive(false);
            } else
            {
                Pause();
                pauseButton.SetActive(false);
                resusmeButton.SetActive(true);
            }
        }*/
    }

    public void Resume()
    {
        /*pauseMenuUI.SetActive(false);*/
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume!");
    }
    public void Pause()
    {
        /*pauseMenuUI.SetActive(true);*/
        Time.timeScale = 0f;
        
        GameIsPaused = true;
    }
    public void LoadMenu(string s)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(s);
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
      
        
    }

    public void restartGame()
    {

        if (reStart.activeInHierarchy == true && gameOverBackDrop.activeInHierarchy == true)
        {        
            reStart.SetActive(false);
            gameOverBackDrop.SetActive(false);
        }
        else
        {
            reStart.SetActive(true);
            gameOverBackDrop.SetActive(true);
        }


    }
}


