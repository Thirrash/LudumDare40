using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipDepth : MonoBehaviour {
    public GameObject Ship;
    public Image Img;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Img.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Lerp(-31.0f, 233.0f, Ship.transform.position.y / 100.0f));
	}
}
