using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneTOLoad;

    private void OnTriggerEnter(Collider other)
    {
 
        if (other.CompareTag("DumpAreaSceneLoader"))
        {
            Debug.Log("Scene Loaded");
            SceneManager.LoadScene(sceneTOLoad);
        }
    }






}
