using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBlades : MonoBehaviour {
    public float speed = 100;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        rotate();
	}

    void rotate()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
