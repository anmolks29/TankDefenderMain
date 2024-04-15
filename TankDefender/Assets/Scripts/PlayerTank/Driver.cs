using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{

    public float m_Speed = 6f;
    public float m_TurnSpeed = 90f;
    public float m_IncreasedSpeed = 12f;
    public float m_IncreasedTurnSpeed = 180f;
    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;


   /* float steerSpeed = 60.0f;
    float moveSpeed = 5.0f;
    float increasedMoveSpeed = 8.0f;
    float increasedSteerSpeed = 90.0f; */
    public int shootingStarDuration = 15;
    
    [SerializeField] AudioSource tankEngineIdle;
    [SerializeField] AudioSource tankEngineMoving;
    public bool isShootinngStarRunning = false;

    public Coroutine shootingStarCoroutine;
    public static Driver instance;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {

        m_MovementInputValue = 0;
        m_TurnInputValue = 0;
    }
    private void Start()
    {
        instance = this;
        m_TurnAxisName = "Horizontal";
        m_MovementAxisName = "Vertical";
       
    }
    void Update()
    {
        /* float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
         float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
         transform.Rotate(0, steerAmount, 0);
         transform.Translate(0, 0, moveAmount);*/


        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
        Move();
        Turn();
        bool isMoving = Mathf.Abs(m_MovementInputValue) > 0.01f || Mathf.Abs(m_TurnInputValue) > 0.01f;

        if (SpawningPowerUps.instance.isShootingStarCollected)
        {
            
            shootingStarCoroutine = StartCoroutine(IncreaseTankSpeed());
            
        }
        if (isMoving && !tankEngineMoving.isPlaying)
        {
            tankEngineIdle.Stop();
            tankEngineMoving.Play();
        }
        else if (!isMoving && tankEngineMoving.isPlaying)
        {
            tankEngineMoving.Stop();
            tankEngineIdle.Play();
        }

    } 

        IEnumerator IncreaseTankSpeed ()
        {
            isShootinngStarRunning = true;
            SpawningPowerUps.instance.shootingStarObj.SetActive(true);
            m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
            m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
            Move();
            Turn();
            /*transform.Rotate(0, increasedSteerAmount, 0);
            transform.Translate(0, 0, increasedMoveAmount);*/

            yield return new WaitForSeconds(shootingStarDuration);
            
            SpawningPowerUps.instance.shootingStarObj.SetActive(false);
            SpawningPowerUps.instance.isShootingStarCollected = false;

            isShootinngStarRunning = false;

        }

        void Move()
        {
            Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        }


        void Turn()
        {
            float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
        }

   
   

   


}
