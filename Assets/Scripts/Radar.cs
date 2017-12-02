using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

    public GameObject[] Rockets;
    public GameObject[] Treasures;
       
	// Use this for initialization
	void Start () {
        Rockets = GameObject.FindGameObjectsWithTag("rocket");
        Rockets = GameObject.FindGameObjectsWithTag("tresure");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
