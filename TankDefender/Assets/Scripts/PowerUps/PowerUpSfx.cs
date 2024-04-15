using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSfx : MonoBehaviour
{

    public ParticleSystem powerUpLoopingParticle;
    public AudioSource powerUpAppear;
    
    public static PowerUpSfx instance;


    private void Start()
    {
        instance = this;
    }

    public void PowerUpParticleLoop()
    {

    }

    
    

}
