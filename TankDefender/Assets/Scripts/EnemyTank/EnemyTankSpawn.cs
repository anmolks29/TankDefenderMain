using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankSpawn : MonoBehaviour
{
    //public GameObject enemytank;
    public GameObject[] enemyTank = new GameObject[0];
    //public bool stopSpawning = false;
    public bool spawningEnemy = false;
    private float spawnTime;
    private float spawnDelay;
    private Vector3 spawnPosX;
    private System.Random random;
    private int numberOfSpwnedTank = 0;


    public GameObject[] enemySpawned = new GameObject[0];
    public static EnemyTankSpawn instance;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        instance = this;
        //InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);

    }

    
    
    // Update is called once per frame
    void Update()
    {
        spawnPosX = new Vector3(Random.Range(72.0f, -85.0f), 0, 50.0f);
        spawnTime = Random.Range(0.5f,1.55f);
        spawnDelay = Random.Range(3f, 10f);

        if (spawningEnemy == false)
        {
            StartCoroutine(SpawnEnemyTank());
        }
        EnemySpawnedCollector();
        
    }
   /* public void SpawnEnemy()
    {
        int randomTankIndex = Random.Range(0, enemyTank.Length);
        Instantiate(enemyTank[randomTankIndex], spawnPosX, Quaternion.identity);
        if (stopSpawning )
        {
            CancelInvoke("SpawnEnemy");
            
        }

    }*/
    public IEnumerator SpawnEnemyTank()
    {
        
        spawningEnemy = true;
        int randomTankIndex = Random.Range(0, enemyTank.Length);
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(enemyTank[randomTankIndex], spawnPosX, Quaternion.identity);
        numberOfSpwnedTank++;
        Debug.Log("Number of Tanks Spawned" + numberOfSpwnedTank);
        spawningEnemy = false;
    }
    public void EnemySpawnedCollector()
    {
        
    }
    public void  DestroyEnemyAllAtOnce()
    {
        GameObject[] enemySpawned = GameObject.FindGameObjectsWithTag("enemyTank");
        foreach (GameObject enemy in enemySpawned)
        {

            enemy.GetComponent<GrenadeFunction>().EnemyTankSfx();
            Destroy(enemy);
            scoreManager.instance.AddPointAtOnce();
        
        }

       /* for (int i = 0; i < enemySpawned.Length; i++)
        {
            enemySpawned[i].GetComponent<GrenadeFunction>().EnemyTankSfx();
            Destroy(enemySpawned[i]);
            scoreManager.instance.AddPointAtOnce();
            yield return new WaitForSeconds(1);
        }*/

    }

    public void DestroyEnemyLandmine()
    {
        Destroy(gameObject);
    }



}

