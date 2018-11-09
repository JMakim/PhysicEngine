using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKey : MonoBehaviour {
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blue Key Slot") { 
            GameObject.Find("GameController").GetComponent<GameScript>().blue = true;
            rb.isKinematic = true;
        }
    }
}
