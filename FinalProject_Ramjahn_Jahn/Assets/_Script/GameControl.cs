using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public GameObject player;
    public GameObject playerCur;
    public Transform Respawn;
    public Transform Respawn1;
    public Transform Respawn2;
    public Transform Respawn3;
    public Text lifeText;
    public GameObject winText;
    public GameObject loseText;
    public bool checkPoint;
    public bool checkPoint2;
    public bool checkPoint3;
    public bool isDead;
    public bool TargetOn;
    public bool TargetOff;
    public bool win;
    public bool lose;
    public float life;

	// Use this for initialization
	void Start () {
        playerCur = GameObject.FindGameObjectWithTag("Player");
        life = 3;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
        playerCur = GameObject.FindGameObjectWithTag("Player");

        death();
        CheckPointManager();
        if (win)
        {
            winText.SetActive(true);
            Time.timeScale = 0;
        }
            
        if (lose)
        {
            loseText.SetActive(true);
            Time.timeScale = 0;
        }

        SetlifeTxt();
    }


    void death()
    {
        if(isDead && checkPoint)
        {
            Instantiate(player, Respawn1.transform.position, Respawn1.transform.rotation);
            life--;
        }
        if (isDead && checkPoint2)
        {
            Instantiate(player, Respawn2.transform.position, Respawn2.transform.rotation);
            life--;
        }
        if (isDead && checkPoint3)
        {
            Instantiate(player, Respawn3.transform.position, Respawn3.transform.rotation);
            life--;
        }
        if(isDead && !checkPoint && !checkPoint2 && !checkPoint3)
        {
            Instantiate(player, Respawn.transform.position, Respawn.transform.rotation);
            life--;
        }
    }
    void CheckPointManager()
    {
        if (checkPoint)
        {
            checkPoint2 = false;
            checkPoint3 = false;
        }
        if (checkPoint2)
        {
            checkPoint = false;
            checkPoint3 = false;

        }
        if (checkPoint3)
        {
            checkPoint = false;
            checkPoint2 = false;
        }
    }
    
    void SetlifeTxt()
    {
        lifeText.text = "Life: " + life;
        if (life <= 0)
            lose = true;
    }
}
