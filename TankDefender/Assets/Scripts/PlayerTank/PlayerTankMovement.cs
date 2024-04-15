using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;



    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_OriginalPitch;

    public static PlayerTankMovement instance;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
      
        m_MovementInputValue = 0;
        m_TurnInputValue = 0;
    }

    private void OnDisable()
    {
        //m_Rigidbody.isKinematic =true;
    }
    void Start()
    {
        m_TurnAxisName = "Horizontal";
        m_MovementAxisName = "Vertical";
        //m_OriginalPitch = m_MovementAudio.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    void Turn ()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
