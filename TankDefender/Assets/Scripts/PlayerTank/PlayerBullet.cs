using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float launchSpeed = 40.0f;
    public GameObject objectPrefab;
      
    public static PlayerBullet instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            spawnObject();
            
        }

       /* if (SpawningPowerUps.instance.isShootingStarCollected && Input.GetKeyDown("space"))
        {
            StartCoroutine(ShootingStarBulletFunction());
        }*/
    }

    void spawnObject()
    {
        Vector3 spawnposition = transform.position;
        Quaternion spawnrotation = transform.parent.rotation;

        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = localXDirection * launchSpeed;

        GameObject newObject = Instantiate(objectPrefab, spawnposition, spawnrotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;
    }

   

   /* IEnumerator ShootingStarBulletFunction()
    {
        Vector3 spawnposition = transform.position;
        Quaternion spawnrotation = transform.parent.rotation;

        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = localXDirection * launchSpeed;

        GameObject newObject = Instantiate(shootingStarBullets, spawnposition, spawnrotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;
        yield return new WaitForSeconds (Driver.instance.shootingStarDuration);
    }*/

}
