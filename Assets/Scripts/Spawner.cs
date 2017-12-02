using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float highOffset;
    public GameObject Teren;
    public GameObject Ting;
    private Terrain ter;
    int size = 3;
    public int differ = 10; 
    // Use this for initialization
	void Start () {
        Teren = GameObject.FindGameObjectWithTag("Dno");
        ter = Teren.GetComponent<Terrain>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
