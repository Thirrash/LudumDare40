using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour {

    public GameObject lodz;
    public float force = 0.005f;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {
            lodz.GetComponent<Rigidbody>().AddTorque(new Vector3(0,-1,0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            lodz.GetComponent<Rigidbody>().AddTorque(new Vector3(0,1,0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            lodz.GetComponent<Rigidbody>().AddTorque(new Vector3(-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            lodz.GetComponent<Rigidbody>().AddTorque(new Vector3(1, 0, 0));
        }
    }
}
