using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CrateHealth : MonoBehaviour
{
    public float startingHealth = 100.0f;
    public Slider slider;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;

    //public PauseMenu screenManager;
    //public GameObject pauseMenu;
    public float currentHealth;
    private bool dead;

    public static CrateHealth instance;
    private void Start()
    {
        //PauseMenu screenManager = GetComponent<PauseMenu>();
        instance = this;
    }
    private void OnEnable()
    {
        currentHealth = startingHealth;
        dead = false;
        SetHealthUI();
    }

    public void TakeDamage(int amount)
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

    public void SetHealthUI()
    {
        slider.value = currentHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth);

    }
    public void HealCrate()
    {
        currentHealth = startingHealth;
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {

            TakeDamage(20);

            Destroy(collision.gameObject);


        }

        if (collision.gameObject.tag == "playerMissile")
        {

            TakeDamage(10);

            Destroy(collision.gameObject);


        }

    }

}
