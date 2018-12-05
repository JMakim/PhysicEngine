using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour {
    //public float speed;
    //public Rigidbody rb;
	// Use this for initialization
	void Start () {
        //speed = 5f;
        //rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //rb.AddForce(this.transform.forward * 1000, ForceMode.Impulse);
        this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 10;
        Destroy(this.gameObject, 8.0f);
    }
}
