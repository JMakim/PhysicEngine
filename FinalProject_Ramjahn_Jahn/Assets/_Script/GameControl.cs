using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public GameObject player;
    public GameObject playerCur;
    public Transform Respawn;
    public Transform Respawn2;
    public Transform Respawn3;
    public bool checkPoint;
    public bool checkPoint2;
    public bool checkPoint3;
    public bool isDead;


	// Use this for initialization
	void Start () {
        playerCur = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update () {
        playerCur = GameObject.FindGameObjectWithTag("Player");
        death();
    }


    void death()
    {
        if(isDead && checkPoint)
        {
            Instantiate(player, Respawn.transform.position, Respawn.transform.rotation);
        }
        if (isDead && checkPoint2)
        {
            Instantiate(player, Respawn2.transform.position, Respawn2.transform.rotation);
        }
        if (isDead && checkPoint3)
        {
            Instantiate(player, Respawn3.transform.position, Respawn3.transform.rotation);
        }
    }

    
}
