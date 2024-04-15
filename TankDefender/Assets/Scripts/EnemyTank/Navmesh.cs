using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{

    public Transform target;
    private NavMeshAgent agent;
    
    public GameObject[] navCollector = new GameObject[0];
    public static Navmesh instance;

    public bool isClockCoroutineRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        instance = this;       
    }

    // Update is called once per frame
    void Update()
    {
        AllNavOnScreen();
        /* if (EnemyTankLookAt.instance.lookAtTriggered)
         {
             transform.LookAt(target);
         }*/
        

    }
    

   

   public  IEnumerator AgentFreeze()
    {
       GameObject[] enemyNav = GameObject.FindGameObjectsWithTag("enemyTank");
       isClockCoroutineRunning = true;
        
        foreach (GameObject go in enemyNav) 
        {
            go.GetComponent<NavMeshAgent>().isStopped = true;
            //agent.isStopped = true;
            
        }
        yield return new WaitForSeconds(15);
        foreach (GameObject go in enemyNav)
        {
            go.GetComponent<NavMeshAgent>().isStopped = false;
            //agent.isStopped = true;
            
        }
        //agent.isStopped = false;
        
        isClockCoroutineRunning = false;

    }

    public void AllNavOnScreen ()
    {

        GameObject[] navCollector = GameObject.FindGameObjectsWithTag("enemyTank");
    }


}
