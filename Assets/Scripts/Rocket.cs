using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public float speed = 0.1f;
    public float range = 5.0f;
    public float time = 0.0f;
    private GameObject ship;
    public GameObject explosion;
    public GameObject model;
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

        if(speed==0)
        {
            time += Time.deltaTime;
            if(time>7)
            {
                Destroy(gameObject);
            }
        }
	}

    void Blow()
    {
        model.SetActive(false);
        speed = 0;
        explosion.SetActive(true);
    }
}
