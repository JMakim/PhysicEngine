using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody rb;
    public GameControl gc;
    public bool inAir;
    public bool jmpStart;
    public bool TargetOn;
    public bool levitate;
    public float leviDura = 5;






    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        GameObject g = GameObject.FindGameObjectWithTag("GameController");
        gc = g.GetComponent<GameControl>();
        gc.isDead = false;
        leviDura = 5;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject g = GameObject.FindGameObjectWithTag("GameController");
        gc = g.GetComponent<GameControl>();
        Movement();
        levi();
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
            if(Input.GetKeyUp(KeyCode.R))
            {
                gc.isDead = true;
                Destroy(this.gameObject);                
            }
        }
    }

    void levi()
    {
        if(levitate)
        {
            leviDura -= Time.deltaTime * 1;
            this.rb.useGravity = false;
            if (leviDura <= 0)
                {
                    this.rb.useGravity = true;
                    levitate = false;
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InitJump")
        {
            rb.AddForce(this.transform.up * 30, ForceMode.Impulse);
            rb.AddForce(this.transform.forward * 75, ForceMode.Impulse);
            jmpStart = true;
        }
        if(other.tag == "JmpStop")
        {
            jmpStart = false;
        }
        if(other.tag == "CheckPoint")
        {
            gc.checkPoint = true;
            gc.checkPoint2 = false;
            gc.checkPoint3 = false;
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
            other.attachedRigidbody.isKinematic = false;
        }
        if (other.tag == "Death")
        {
            gc.isDead = true;
            Destroy(this.gameObject);
        }

        if(other.tag == "TargetOn")
        {
            TargetOn = true;
        }
        if (other.tag == "TargetOff")
        {
            TargetOn = false;
        }
        if(other.tag == "Levitate")
        {
            levitate = true;
        }
        if(other.tag == "win")
        {
            gc.win = true;
        }
    }
}
