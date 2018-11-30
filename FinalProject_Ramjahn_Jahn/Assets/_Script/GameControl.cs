using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public GameObject player;
    public Transform Respawn;
    public bool checkPoint;
    public bool checkPoint1;
    public bool checkPoint2;
    public bool checkPoint3;
    public bool isDead;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void death()
    {
        if(isDead && checkPoint)
        {
            Instantiate(player, Respawn.transform.position, Respawn.transform.rotation);
        }
    }

    
}
