using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float startingHealth = 100.0f;
    public Slider slider;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;
    

    public float currentHealth;
    public bool dead;
    




    private void Start()
    {
        currentHealth = startingHealth;
        dead = false;
        SetHealthUI();
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;
        SetHealthUI();
        
     
        if (currentHealth <= 0f && !dead)
        {
            dead = true;
            Destroy(gameObject);
            scoreManager.instance.GameOver();
        }
    }

    public void Heal ()
    {
        currentHealth = startingHealth;
    }

    public void SetHealthUI ()
    {
        slider.value = currentHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth);
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(10);
            Destroy(collision.gameObject);
      
        }

    }


}
