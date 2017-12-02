using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {
    public GameObject Sm;
    public float time;
    float t;

	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().AddForce(0, 7, 0);
        t += Time.deltaTime;
        if(t>time)
        {
            Sm.SetActive(false);
        }
        if((t-3)>time)
        {
            Destroy(gameObject);
        }
	}
}
