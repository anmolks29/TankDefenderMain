using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class spinUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeed;
    public float minSpeed;
    float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        transform.Rotate(0f, speed *Time.deltaTime, 0, Space.Self);
    }

    
}
