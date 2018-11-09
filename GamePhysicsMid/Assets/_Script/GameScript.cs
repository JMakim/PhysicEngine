using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    //public GameObject RedKey;
   
    public bool red;
    public bool blue;
    public bool yellow;
    public bool purple;
    public GameObject ramp;
    public GameObject purlpleSlot;
    public GameObject purpleKey;
    public GameObject menu;
	// Use this for initialization
	void Start () {
        ramp.SetActive(false);
        purlpleSlot.SetActive(false);
        purpleKey.SetActive(false);
        Time.timeScale = 0;
        
    }
	
	// Update is called once per frame
	void Update () {
		if(red && blue && yellow)
        {
            ramp.SetActive(true);
            purlpleSlot.SetActive(true);
            purpleKey.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu.activeInHierarchy == true)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
            
        }
	}

}