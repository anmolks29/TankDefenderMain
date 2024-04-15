using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeFunction : MonoBehaviour
{
    public ParticleSystem tankExplode;
    public static GrenadeFunction instance;
    
    public AudioSource tankExplodeSound;

    // Start is called before the first frame update
   public void Start()
    {
        tankExplode = GetComponentInChildren<ParticleSystem>();
        instance = this;
        if (tankExplode == null)
        {
            Debug.LogError("Particle System reference is not set!");
            return;
        }
        instance = this;
    }

    
    public void EnemyTankSfx()
    {
        if (tankExplode != null)
        {

            tankExplode.Play();
            tankExplodeSound.transform.parent = null;
            tankExplodeSound.enabled = true;
            tankExplodeSound.Play();
            
        }
        else
        {
            Debug.LogError("Particle System reference is not set!");
            return;
        }
        
    }

    public void EnemyTankSounds ()
    {
        if (tankExplode != null)
        {
            tankExplodeSound.transform.parent = null;
            tankExplodeSound.enabled = true;
            tankExplodeSound.Play();

        }
    }
    


}
