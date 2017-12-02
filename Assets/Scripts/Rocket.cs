using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public float speed = 0.1f;
    public float range = 5.0f;
    private GameObject ship;
    // Use this for initialization
    void Start () {
        ship = GameObject.FindGameObjectWithTag("Ship");
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed,0,0);
        if(Vector3.Distance(transform.position,ship.transform.position)<=range)
        {
            Blow();
        }
	}

    void Blow()
    {
        Destroy(gameObject);
    }
}
