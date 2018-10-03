using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

 
    public Transform targetTransform;

    private Rigidbody m_rb;
    public float pushForce = 0.0f;
    private bool m_isRunning = false;
    private bool powerStroke = false;
    public float power = 0.0f;



    // Use this for initialization
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            powerStroke = true;
            m_isRunning = true;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            power = pushForce;
            powerStroke = false;
            m_isRunning = true;
        }
    }



    void FixedUpdate()
    {
        if (powerStroke)
            power = power + Time.time;
        if (!powerStroke)
            pushForce = power;
        if (m_isRunning)
            m_rb.AddForce(transform.forward * power);
    }


}
