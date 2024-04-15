using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMinesDeployment : MonoBehaviour
{
    public GameObject landMinesDeploy;
    [SerializeField]
    AudioSource landmineBlastAudio;
    [SerializeField]
    ParticleSystem landmineBlast;
    public static LandMinesDeployment Instance; 
    
    // Start is called before the first frame update
    void Start()
    { 
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.tag);
        if (collision.gameObject.tag == "enemyTank")
        {
            LandMinesSfx();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreManager.instance.AddPointAtOnce();
        }
    }


    private void LandMinesSfx()
    {
        landmineBlastAudio.transform.parent = null;
        landmineBlastAudio.enabled = true;
        landmineBlastAudio.Play();
        landmineBlast.Play();
    }
}


