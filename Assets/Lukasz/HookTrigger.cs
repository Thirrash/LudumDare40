using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookTrigger : MonoBehaviour {

    public delegate void TreasureGrabbed(GameObject a);
    public event TreasureGrabbed OnTreasureGrabbedEvent;

	void Start () {
        OnTreasureGrabbedEvent += OnTreasureGrabbed;
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            OnTreasureGrabbedEvent.Invoke(other.gameObject);
        }
    }

    void OnTreasureGrabbed(GameObject treasure)
    {
        treasure.transform.SetParent(this.gameObject.transform);
    }
}
