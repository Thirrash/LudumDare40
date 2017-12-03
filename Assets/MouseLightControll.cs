using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLightControll : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100000, 1 << 10))
        {
            transform.forward = hit.point - transform.position;
        }

    }
}
