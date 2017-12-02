using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour {

    public float intervial = 2f;
    public float time = 0.05f;
    public float t = 0;
    private bool b = false;
    public GameObject obj;
    private Light lit;
	// Use this for initialization
	void Start () {
        lit = obj.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if(t>intervial && !b)
        {
            lit.intensity = 0;
            t = 0;
            b = !b;
        }
        if(t>time && b)
        {
            lit.intensity = 0.4f;
            t = 0;
            b = !b;
        }
	}
}
