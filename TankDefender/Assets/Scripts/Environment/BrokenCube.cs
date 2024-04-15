using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCube : MonoBehaviour
{
    public GameObject brokenPrefab;
    

    // Update is called once per frame
    public void spawnBrokenCube ()
    {
        Instantiate(brokenPrefab, transform.position, transform.rotation);
    }
}
