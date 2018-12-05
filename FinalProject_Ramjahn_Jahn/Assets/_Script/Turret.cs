using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public Transform target;
    public GameObject playerCur;
    public GameObject bullet;
    public Transform bullSpawn;
    public float delay;
    public float nextShot = 0;
    public Player player;
    public float speed;

    // Use this for initialization
    void Start () {
        delay = 3f;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerCur = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = p.GetComponent<Player>();
        Track();


        fire();
    }

    void Track()
    {
        if (player.TargetOn == true)
        { 

            Vector3 targetDir = target.position - transform.position;

            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    void fire()
    {
        if(player.TargetOn)
        {
            if (Time.time>nextShot)
            {
                nextShot = Time.time + delay;
                Instantiate(bullet, bullSpawn.position, bullSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 5;

            }
        }
    }
}
