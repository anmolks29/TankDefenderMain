using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replace : MonoBehaviour
{

    public GameObject cube;
    public GameObject brokenCube;
    public bool replaced = false;
    


   
    void ReplaceObj(GameObject obj1, GameObject obj2)
    {
        Instantiate(obj2, obj1.transform.position, Quaternion.identity);
        Destroy(obj1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
           
            Destroy(collision.gameObject);
            //Destroy(gameObject);
            ReplaceObj(cube, brokenCube);
            
            
        }
        if (collision.gameObject.tag == "playerMissile")
        {
            
            Destroy(collision.gameObject);
            //Destroy(gameObject);
            ReplaceObj(cube, brokenCube);
            
        }
    } 
    public void Update()
    {
       
    }
    

}
