using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SpawningPowerUps : MonoBehaviour
{
    public GameObject firstAidKit;
    public GameObject healthCrate;
    public float spawnTime = 15.0f;  
    private Vector3 spawnPosHealth;
    private Vector3 spawnPos;
    public GameObject[] powerUps = new GameObject[3];
    public GameObject shieldObj;
    public GameObject shootingStarObj;
    public GameObject mineObj;
    
    public bool isPowerUpActive = false;
    public bool isGrenadeCollected = false;
    public bool isMinesCollected = false;
    public bool isCrateHealthCollected = false;
    public bool isMinesCoroutineRunning = false;
    public bool isClockCoroutineRunning = false;
    public bool isClockCollected = false;
    public bool isShieldCollected = false;
    public bool isShootingStarCollected = false;
    public bool isShieldCoroutineRunning = false;
    
    
    public AudioSource powerUpPicked;
    public AudioSource powerUpAppear;

    Coroutine shieldCoroutine;
    Coroutine landMinesCoroutine;
    Coroutine clockCoroutine;
    [SerializeField] TextMeshProUGUI remainingText;
    public NavMeshAgent enemyTankNav;
   // public BaseToDefendHealth crateHealth;
    private HealthSystem healthSystem;

    public static SpawningPowerUps instance;
   

    // Start is called before the first frame update
    void Start()
    {
        
        healthSystem = GetComponent<HealthSystem>();
        enemyTankNav = GetComponent<NavMeshAgent>();
       // crateHealth = GetComponent<BaseToDefendHealth>();
        StartCoroutine(HealthSpawnPowerUps());
        StartCoroutine(CrateHealthPowerUps());
        StartCoroutine(SpawnPowerUps());
        instance = this;
        //shieldObj = GetComponentInChildren<GameObject>();
        //shootingStarObj = GetComponentInChildren<GameObject>();

        
    }
    private void Update()
    {
        
         if (isMinesCollected && Input.GetKeyDown(KeyCode.LeftAlt))
         {

            PlayerDeployedPowerUpsSpawner.instance.LandMinesDeployed();
            PowerUpAppearSound();
            mineObj.SetActive(false);
            isMinesCollected = false;

         }

    }

    IEnumerator HealthSpawnPowerUps()
    {
        while (true)  
        {
            yield return new WaitForSeconds(spawnTime);

            if (!isPowerUpActive && healthSystem.currentHealth < 50.0f)
            {
                PowerUpAppearSound();
                HealthSpawnPowerUp();
                isPowerUpActive=true;
                
            }
        }
    }

    IEnumerator CrateHealthPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            if (!isCrateHealthCollected && BaseToDefendHealth.instance.currentHealth < 90.0f)
            {
                PowerUpAppearSound();
                CrateHealthSpawnPowerUp();
                isCrateHealthCollected = true;
                Debug.Log("Health Crate");
            }
        }
    }

    IEnumerator SpawnPowerUps()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            if (!isPowerUpActive)
            {
                PowerUpAppearSound();
                SpawnPowerUp();
                
            }
        }
    }
   

    public void HealthPowerUpCollected()
    {
        isPowerUpActive = false;
        healthSystem.Heal();
        healthSystem.SetHealthUI();
        PowerUpPickedSound();
    }
    public void CratePowerUpCollected()
    {
        isCrateHealthCollected = false;
        BaseToDefendHealth.instance.HealCrate();
        BaseToDefendHealth.instance.SetHealthUI();
        PowerUpPickedSound();
    }
    public void PowerUpCollected()
    {
        isPowerUpActive = false;
        PowerUpPickedSound();
    }
    

    void HealthSpawnPowerUp()
    {
        spawnPosHealth = new Vector3(Random.Range(40.0f, -40.0f), 4.77f, Random.Range(10.0f, 40.0f));
        Instantiate(firstAidKit, spawnPosHealth, Quaternion.identity);
    }

    void CrateHealthSpawnPowerUp()
    {
        spawnPosHealth = new Vector3(Random.Range(40.0f, -40.0f), 4.77f, Random.Range(10.0f, 40.0f));
        //spawnPos = new Vector3(Random.Range(-4.0f, 4.0f), 7.77f, Random.Range(7.0f, -7.0f));
        Instantiate(healthCrate, spawnPosHealth, Quaternion.identity);
    }

    void SpawnPowerUp()
    {
        spawnPos = new Vector3(Random.Range(40.0f, -40.0f), 4.77f, Random.Range(10.0f, 40.0f));
        //spawnPos = new Vector3(Random.Range(-4.0f, 4.0f), 4.77f, Random.Range(7.0f, -7.0f));
        int randomIndex = Random.Range(0, powerUps.Length);

        GameObject spawnedPowerUp = Instantiate(powerUps[randomIndex], spawnPos, Quaternion.identity);

        isPowerUpActive = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("FirstAidKit"))
        {
            Debug.Log(other.gameObject.name);
            HealthPowerUpCollected();
            Destroy(other.gameObject);
            Debug.Log("Current Health Inumerator " + healthSystem.currentHealth);

        }

        if (other.CompareTag("CrateHealth"))
        {
            Debug.Log(other.gameObject.name);
            CratePowerUpCollected();
            Destroy(other.gameObject);
            Debug.Log("Crate Health Inumerator ");

        }
        if (other.CompareTag("grenade"))
        {
            
            PowerUpCollected();
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
            isGrenadeCollected = true;
            Grenade();
            

        }
        if (other.CompareTag("landMines"))
        { 
            if (isMinesCoroutineRunning)
            {
                StopCoroutine(landMinesCoroutine);
                //StopAllCoroutines();
                Debug.Log("LandMines Coroutine stopped");
            }
            PowerUpCollected();
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
            isMinesCollected = true;
            
            landMinesCoroutine = StartCoroutine(LandMines());
            
            mineObj.SetActive(true);
            


        }
        if (other.CompareTag("clock"))
        {
            if (Navmesh.instance.isClockCoroutineRunning)
            {
                StopCoroutine(clockCoroutine);
                Debug.Log("Clock stop coroutine");
            }

            PowerUpCollected();
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
            isClockCollected = true;
            clockCoroutine = StartCoroutine(Navmesh.instance.AgentFreeze());
            isClockCollected = false;
        }
        if (other.CompareTag("Shield"))
        {
            if (isShieldCoroutineRunning)
            {
               StopCoroutine(shieldCoroutine);
              //StopAllCoroutines();
                Debug.Log("Coroutine shield stopped");
            }
            PowerUpCollected();
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
            isShieldCollected = true;
            shieldCoroutine = StartCoroutine(Shield());
            
        }
        if (other.CompareTag("ShootingStar"))
        {
            if (Driver.instance.isShootinngStarRunning)
            {
                StopCoroutine(Driver.instance.shootingStarCoroutine);
                Debug.Log("ShootingStar stop coroutine");
            }
            PowerUpCollected();
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
            isShootingStarCollected = true;
 
        }
    }

   

    private void Grenade ()
    {
        if (isGrenadeCollected)
        {
            
            EnemyTankSpawn.instance.DestroyEnemyAllAtOnce();
            
            isGrenadeCollected = false;
            Debug.Log("GrenadeFunction Called");
        }
    }

   IEnumerator LandMines()
    {

        Debug.Log("LandMines Called before");

        if  (isMinesCollected)
        {
            
            isMinesCoroutineRunning = true;
            yield return new WaitForSeconds(10);
            mineObj.SetActive(false);
            Debug.Log("LandMines Called");
            isMinesCollected = false;
            isMinesCoroutineRunning = false;
        }
    }
        

    IEnumerator Shield()
    {
        
        if (isShieldCollected)
        {
            isShieldCoroutineRunning = true;
            shieldObj.SetActive(true);
            yield return new WaitForSeconds(25);
            shieldObj.SetActive(false);
            isShieldCollected=false;
            isShieldCoroutineRunning = false;
        }
        
    }


  

    public void PowerUpPickedSound()
    {

        powerUpPicked.enabled = true;
        powerUpPicked.Play();
    }

    public void PowerUpAppearSound()
    {

        powerUpAppear.enabled = true;
        powerUpAppear.Play();
        Debug.Log("Appear Sound played");
    }










}
