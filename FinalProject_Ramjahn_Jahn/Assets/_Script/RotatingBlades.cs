using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBlades : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotate();
	}

    void rotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime);
    }
}
