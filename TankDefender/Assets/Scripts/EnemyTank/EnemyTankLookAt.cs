using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankLookAt : MonoBehaviour
{

    public Transform target;
    private float turnVelocity;
    private float turnCalmTime = 0.1f;
    public bool lookAtTriggered = false;
    // Start is called before the first frame update

    public static EnemyTankLookAt instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (lookAtTriggered == true)
        {
            transform.LookAt(target.position);
            lookAtTriggered = false;
            Debug.Log("Look At Crate");
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyTank"))
        {
            lookAtTriggered = true;
           // EnemyRotation();
           
            /* GameObject[] lookAtTriggerObject = GetComponents<GameObject>();
            foreach (GameObject go in lookAtTriggerObject)
            {
                go.GetComponent<GameObject>().transform.LookAt(go.transform.position);
            }*/

        }
    }

    void EnemyRotation()
    {
        Vector3 moveDirection = new Vector3(target.position.x, target.position.y, target.position.z).normalized;
        //if (moveDirection.magnitude >= 0.1f)

        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnCalmTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f); // To Rotate left right, rotate in y axis.



    }
}
