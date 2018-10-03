using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

 
    public Transform targetTransform;

    private Rigidbody m_rb;
    public float pushForce = 0.0f;
    public bool m_isRunning = false;
    public bool powerStroke = false;
    public bool start = false;
    public float power = 0.0f;
    public float drag = 1.0f;
   



    // Use this for initialization
    void Start()
    {
        start = false;
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!start) { 
            powerStroke = true;
            start = true;
            }
        }


        if(Input.GetKeyUp(KeyCode.Space))
        {
            powerStroke = false;

        }
       if (powerStroke)
        {
            power = Time.time * 10;
        }
       
       
    }



    void FixedUpdate()
    {
        if(!powerStroke && start)
        {  
            m_rb.AddForce(Vector3.forward * power);
            

            
            
        }

  
    }


}
