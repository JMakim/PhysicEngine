using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

    Rigidbody m_Rigidbody;
    public Slider powerBar;
    public bool powerUp = false;
    public bool powerSwitch = false;
    public float power;

	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
     
	}
	
	// Update is called once per frame
	void Update () {
        movement();
        resetPlayer();

	}

    void movement()
    {
        powerBar.value = power / 10;
        //if (!powerUp)
            //{
            //    if (Input.GetKey(KeyCode.D))
            //        powerUp = true;
            //    if (Input.GetKey(KeyCode.A))
            //        powerUp = true;
            //    if (Input.GetKey(KeyCode.S))
            //        powerUp = true;
            //    if (Input.GetKey(KeyCode.W))
            //        powerUp = true;
            //}

            if (!powerUp)
            {
                if (Input.GetKeyUp(KeyCode.W))
                {
                    m_Rigidbody.velocity = Vector3.forward * (power /10 );
                    //powerUp = false;
                    power = 0;
                }

                if (Input.GetKeyUp(KeyCode.A))
                {
                    m_Rigidbody.velocity = Vector3.left * (power / 10);
                    //powerUp = false;
                    power = 0;
                }

                if (Input.GetKeyUp(KeyCode.S))
                {
                    m_Rigidbody.velocity = Vector3.back * (power / 10);
                    //powerUp = false;
                    power = 0;
                }

                if (Input.GetKeyUp(KeyCode.D))
                {
                    m_Rigidbody.velocity = Vector3.right * (power / 10);
                    //powerUp = false;
                    power = 0;
                }
            }

        
        if (powerUp)
        {
            if (!powerSwitch)
                power++;
            if (powerSwitch)
                power--;
            if(Input.GetKeyDown(KeyCode.Space))
                powerUp = false;
        }

        if (!powerUp && power == 0)
            if (Input.GetKeyDown(KeyCode.Space))
                powerUp = true;


        if (power <= 0 && power < 101)
            powerSwitch = false;
        if (power >= 100)
            powerSwitch = true;

        if (Input.GetKey(KeyCode.F))
            m_Rigidbody.velocity = Vector3.zero;
    }

    void resetPlayer()
    {
        if (Input.GetKey(KeyCode.R))
            this.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }
}
