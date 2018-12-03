using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody rb;
    public bool inAir;
    public bool jmpStart;
    public GameControl gc;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        GameObject g = GameObject.FindGameObjectWithTag("GameController");
        gc = g.GetComponent<GameControl>();
        gc.isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        initJump();
	}


    void Movement()
    {
        if (!jmpStart)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.right * -5 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.forward * 5 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.forward * -5 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * 5 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (!inAir)
                {
                    transform.position += Vector3.up * 5 * Time.deltaTime;
                }
            }
        }
    }

    void initJump()
    {
        if(jmpStart)
        {
            transform.position +=  Vector3.up * 9 * Time.deltaTime;
            transform.position +=  Vector3.forward * 8 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InitJump")
        {
            jmpStart = true;
        }
        if(other.tag == "JmpStop")
        {
            jmpStart = false;
            gc.checkPoint = true;
            gc.checkPoint2 = false;
            gc.checkPoint3 = false;

        }
        if(other.tag == "Death")
        {
            gc.isDead = true;
            Destroy(this.gameObject);
        }
        if(other.tag == "CheckPoint2")
        {
            gc.checkPoint = false;
            gc.checkPoint2 = true;
            gc.checkPoint3 = false;
        }
        if (other.tag == "CheckPoint3")
        {
            gc.checkPoint = false;
            gc.checkPoint2 = false;
            gc.checkPoint3 = true;
        }
        if (other.tag == "falseFloor")
        {
            other.attachedRigidbody.useGravity = true;
        }
    }
}
