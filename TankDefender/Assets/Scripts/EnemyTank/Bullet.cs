
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public bool spawningBullet = false;
    private float spawnDelayReduced;
    private float spawnDelay;
   
   
    private void Start()
    {
        //InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        
    }
    // Update is called once per frame
    void Update()
    {
        spawnDelay = Random.Range(3, 5);
       // spawnDelayReduced = (Random.Range(3f, 5f));
       
        if (spawningBullet == false )
        {
            StartCoroutine(SpawnBullet());
            
        }

        
    }
   /* public void SpawnObject ()
    {
        Instantiate(bullet, transform.position, transform.parent.rotation);
        Debug.Log("Bullet Spawned");
        if (stopSpawning)
        {
            CancelInvoke("SpwanObject");
        }    
    }*/

    public IEnumerator SpawnBullet()
    {
        spawningBullet = true;
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(bullet, transform.position, transform.parent.rotation);
       // Debug.Log("Bullet Spawned");
        spawningBullet = false;
    }

    /*public IEnumerator SpawnBulletFaster()
    {
        spawningBullet = true;
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(bullet, transform.position, transform.parent.rotation);
        Debug.Log("Faster Bullet Spawned");
        spawningBullet = false;
    }*/



}
