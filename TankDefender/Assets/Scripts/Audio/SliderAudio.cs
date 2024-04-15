using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderAudio : MonoBehaviour
{
    public GameObject mainMusic;
    public GameObject sfx;
    public GameObject helpContent;

    private void Start()
    {
        //StartCoroutine(ButtonCLicked());
    }



    public void  ButtonClicked ()
    {
        
            if (sfx.activeInHierarchy == true && mainMusic.activeInHierarchy == true)
            {
                //yield return new WaitForSeconds(2);
                sfx.SetActive(false);
                mainMusic.SetActive(false);
                Debug.Log("Slider activated");
            

            }
            else
            {
                sfx.SetActive(true);
                mainMusic.SetActive(true);
                Debug.Log("Slider Deactivated");
            }
            
        
    }

    public void HelpButtonClicked ()
    {
        if (helpContent.activeInHierarchy == false)
        {
            helpContent.SetActive(true);
            PauseMenu.instance.Pause();
        }
        else 
        { 
            helpContent.SetActive(false);
            PauseMenu.instance.Resume();
        }
    }

   
}
