using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisDestroy : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Delay());
    }
   
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
