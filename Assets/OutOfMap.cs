using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfMap : MonoBehaviour {
    public Text trext;
    private Collider playerCollider;
    private ShipBallaster ballaster;
    public float Damage;
    public float Delay;
    
	// Use this for initialization
	void Start () {
        GameObject ship = GameObject.FindGameObjectWithTag("Ship");
        playerCollider = ship.GetComponent<BoxCollider>();
        ballaster = ship.GetComponent<ShipBallaster>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerExit(Collider other)
    {
        if (other == playerCollider)
        {
            Debug.Log("Out of map!");
            StartCoroutine("BeatTheShitOutOfHim");
            trext.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            Debug.Log("Back on map...");
            StopCoroutine("BeatTheShitOutOfHim");
            trext.enabled = false;
        }
    }

    IEnumerator BeatTheShitOutOfHim()
    {
        while(true)
        {
            ballaster.CurrentHp -= Damage;
            yield return new WaitForSeconds(Delay);
        }
    }
}
