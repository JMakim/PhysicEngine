using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour {

    public Rigidbody Rb;

    public GameObject xAxis;
    public GameObject yAxis;

    public bool dirLock = false;

    public float power;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        Aim();
        Kick();
	}

    void Aim()
    {
        if (!dirLock)
        {
            if (Input.GetKey(KeyCode.A))
            {
                xAxis.transform.Rotate(Vector3.up * -10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                xAxis.transform.Rotate(Vector3.up * 10 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                yAxis.transform.Rotate(Vector3.right * -10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                yAxis.transform.Rotate(Vector3.right * 10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (!dirLock)
                    dirLock = true;
            }
        }
    }

    void Kick()
    {
        if (dirLock)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Rb.AddForce(xAxis.transform.forward * power);
                Rb.AddForce(yAxis.transform.forward * power);
            }
        }
    }
}
