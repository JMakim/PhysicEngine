using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class direction : MonoBehaviour {

    public Slider powerBar;

    public Rigidbody Rb;

    public GameObject xAxis;
    public GameObject yAxis;
    public GameObject ball;
    public Transform spawn;
    public GameObject goal;

    public bool dirLock = false;

    public bool powerUp = false;
    public bool powerSwitch = false;
    public float power;

    private float timer;



    // Use this for initialization
    void Start () {
        ball = GameObject.Find("ball");
        dirLock = false;
        powerUp = false;
 
        
    }
	
	// Update is called once per frame
	void Update () {
        Aim();
        Kick();
        resetBall();


        powerBar.value = power;

    }

    void Aim()
    {
        if (!dirLock)
        {
                if (Input.GetKey(KeyCode.A))
                {
                    xAxis.transform.Rotate(Vector3.up * -20 * Time.deltaTime);


            }
                if (Input.GetKey(KeyCode.D))
                {
                    xAxis.transform.Rotate(Vector3.up * 20 * Time.deltaTime);
                }
            

            if (Input.GetKey(KeyCode.W))
            {
                yAxis.transform.Rotate(Vector3.right * -20 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                yAxis.transform.Rotate(Vector3.right * 20 * Time.deltaTime);
            }






            if (!dirLock)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    dirLock = true;
                    powerUp = true;
                }
                 
            }
        }



        if (powerUp)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (!powerSwitch)
                    power++;
                if (powerSwitch)
                    power--;
                
            }
            if (Input.GetKeyUp(KeyCode.F))
                    powerUp = false;
        }

        if (power <= 5 && power < 31)
            powerSwitch = false;
        if (power >= 30)
            powerSwitch = true;

    }
    
    void Kick()
    {
        if (dirLock && !powerUp)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rb.AddForce(xAxis.transform.forward * power, ForceMode.Impulse);
                Rb.AddForce(yAxis.transform.forward * power, ForceMode.Impulse);
            }
        }
    }

    void resetBall()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Instantiate(ball, spawn.position, spawn.rotation);
            Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "goal")
            goal.SetActive(true);
    }
}
