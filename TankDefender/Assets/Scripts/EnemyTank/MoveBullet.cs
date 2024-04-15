using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveBullet : MonoBehaviour
{
    float speed = 20.0f;
    [SerializeField]
    private ParticleSystem bulletExplode;
    [SerializeField] AudioSource bulletExplodeSound;
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
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0, 0, Time.deltaTime * speed);
        
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
            bulletIsmoving = true;
            bulletExplodeSound.transform.parent = null;
            PlaySfx();
            bulletExplode.Play();
            Destroy(gameObject);

        }


        if (collision.gameObject.tag == "Tank")
        {
            bulletIsmoving = true;
            bulletExplodeSound.transform.parent = null;
            PlaySfx();
            bulletExplode.Play();
            Destroy(gameObject);
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            bulletIsmoving = true;
            bulletExplodeSound.transform.parent = null;
            PlaySfx();
            bulletExplode.Play();
            Destroy(gameObject);
            Debug.Log("Shield activated");
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