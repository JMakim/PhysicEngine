using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : MonoBehaviour {
    public Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Red Key Slot")
        {
            GameObject.Find("GameController").GetComponent<GameScript>().red = true;
            rb.isKinematic = true;
        }
    }
}
