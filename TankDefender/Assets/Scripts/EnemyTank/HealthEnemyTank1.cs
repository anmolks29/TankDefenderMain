using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemyTank1 : MonoBehaviour
{
    public float startingHealth = 100.0f;
    public Slider slider;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;


    private float currentHealth;
    private bool dead;

    public CollisionPlayerBullet collBullet;
    public GameObject playerBullet;
    
   

    private void Start()
    {
        currentHealth = startingHealth;
        dead = false;
        SetHealthUI();
    }

    private void Awake()
    {
        
    }

    public void TakeDamage (int amount)
    {
        
        currentHealth -= amount;
        SetHealthUI();
        

        if (currentHealth <= 0f && !dead)
        {
            dead = true;
            //GrenadeFunction.instance.tankExplodeSound.Play();
            GrenadeFunction.instance.EnemyTankSounds();
            Destroy(gameObject);
        }
    }

    private void SetHealthUI ()
    {
        slider.value = currentHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth);
        
    }
    public void HandlePlayerBulletCollision(CollisionPlayerBullet collBullet)
    {
        collBullet.bulletExplodeSound.transform.parent = null;
        collBullet.PlaySfx();
        collBullet.bulletExplode.Play();
        TakeDamage(50);
        
    }

    public void HandleEnemyTankBulletCollision()
    {
        TakeDamage(10);
        
        
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "playerMissile")
        {
            CollisionPlayerBullet collBullet = collision.gameObject.GetComponent<CollisionPlayerBullet>();

            if (collBullet != null)
            {
                HandlePlayerBulletCollision(collBullet);
                Destroy(collision.gameObject);
                
                scoreManager.instance.AddPoint();
                
            }
            else
            {
                Debug.LogError("CollisionPlayerBullet component not found on the playerMissile gameObject.");
            }
        }

        if (collision.gameObject.tag == "Bullet")
        {

            HandleEnemyTankBulletCollision();
            
            Destroy(collision.gameObject);
            

        }

    }


}
