using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    public string sceneTOLoad;

    public void sceneChange(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Scene loaded");
    } 

    public void exitGame()
    {
        Application.Quit();

    }
}
