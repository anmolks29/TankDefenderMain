using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeneManagement : MonoBehaviour
{   
    public static SeneManagement instance;
    public static bool GameIsOver = false;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    public void gameOver()
    {
        if (GameIsOver)
        {
            gameOverUI.SetActive(true);
            GameIsOver = false;
        }
    }
}
