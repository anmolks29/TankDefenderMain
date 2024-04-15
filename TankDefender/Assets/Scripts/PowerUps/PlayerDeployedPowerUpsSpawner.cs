using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerDeployedPowerUpsSpawner : MonoBehaviour
{

    [SerializeField] public GameObject landMinesDeploy;
    [SerializeField] public GameObject steelWallDeploy;
    public static PlayerDeployedPowerUpsSpawner instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    public void LandMinesDeployed()
    {
        
        
            Instantiate(landMinesDeploy, transform.position, transform.rotation);
            /*Debug.Log("Land Mines function called");*/
        
            

        
    }

    public void SteelWallDeployed()
    {


        Instantiate(steelWallDeploy, transform.position, Quaternion.identity);
        




    }
}

