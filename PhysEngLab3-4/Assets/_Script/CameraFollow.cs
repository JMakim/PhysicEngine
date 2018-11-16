using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
	// Use this for initialization
	void Start () {

        player = GameObject.Find("ball");
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.Find("ball(clone)");
        transform.position = player.transform.position + offset;
    }
}
