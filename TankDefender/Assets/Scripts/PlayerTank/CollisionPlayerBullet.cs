using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerBullet : MonoBehaviour
{
    
    public ParticleSystem bulletExplode;
    public AudioSource bulletExplodeSound;
    public bool bulletIsmoving = false;
    void Start()
    {
        bulletExplode = GetComponentInChildren<ParticleSystem>();
        if (bulletExplode == null)
        {
            Debug.LogError("Particle System reference is not set!");
            return;
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "debris")
        {
            bulletIsmoving = true;

            bulletExplodeSound.transform.parent = null;
            PlaySfx();
            bulletExplode.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "SteelWall")
        {
            bulletExplodeSound.transform.parent = null;
            PlaySfx();
            bulletExplode.Play();
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Tank")
        {
            bulletExplodeSound.transform.parent = null;
            PlaySfx();
            bulletExplode.Play();
            Destroy(gameObject);
 
        }


        if (collision.gameObject.tag == "Bullet")
        {
            bulletExplodeSound.transform.parent = null;
            PlaySfx();
            bulletExplode.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
       
        }
        if (collision.gameObject.tag == "Player")
        {
            bulletExplodeSound.transform.parent = null;
            
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "objectToDefend")
        {
            bulletExplodeSound.transform.parent = null;
            PlaySfx();
            bulletExplode.Play();
            
            Destroy(gameObject);

        }

    }

    public void PlaySfx()
    {
        if (bulletIsmoving && !bulletExplodeSound.isPlaying)
        {
            bulletExplodeSound.enabled = true;
            bulletExplodeSound.Play();
            bulletIsmoving = false;
            
        }
        else if (!bulletIsmoving && bulletExplodeSound.isPlaying)
        {
            bulletExplodeSound.Stop();
           
        }
    }


}
