using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTime : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI remainingText;
    public int remainingTime = 10;

    public static CountDownTime instance;
    private void Start()
    {
        instance = this;
        
    }
    
    
    

}
