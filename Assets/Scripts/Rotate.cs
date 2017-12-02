using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float rotation=0;
    public GameObject ship;

	// Use this for initialization
	void Start () {
        ship = GameObject.FindGameObjectWithTag("Ship");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
           rotation= ship.GetComponent<Swimming>().sila;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rotation = -ship.GetComponent<Swimming>().sila;
        }
        if(rotation<0)
        {
            rotation += Time.deltaTime;
        }
        else if(rotation>0)
        {
            rotation -= Time.deltaTime;
        }
        transform.Rotate(new Vector3(0,0,rotation));
	}
}
