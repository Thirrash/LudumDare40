using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookTrigger : MonoBehaviour {

    public delegate void TreasureGrabbed(GameObject a);
    public event TreasureGrabbed OnTreasureGrabbedEvent;
    public ChainShoot chainer;

	void Start () {
        OnTreasureGrabbedEvent += OnTreasureGrabbed;
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Tresure")
        {
            if (col.gameObject.GetComponent<Treasure>().bAlreadyPicked)
                return;

            col.gameObject.GetComponent<Treasure>().bAlreadyPicked = true;
            //col.transform.localPosition += new Vector3(0.0f, 4.5f, 0.0f);
            col.gameObject.GetComponent<HingeJoint>().connectedBody = GetComponent<Rigidbody>();
            Debug.Log(gameObject.name);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            if (transform.childCount > 0)
                Destroy(transform.GetChild(0).gameObject);
            OnTreasureGrabbedEvent.Invoke(col.gameObject);
            chainer.bPicked = true;
        }
    }

    void OnTreasureGrabbed(GameObject treasure)
    {
        treasure.transform.SetParent(this.gameObject.transform);
    }
}
