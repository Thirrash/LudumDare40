using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoConnectJoint : MonoBehaviour
{
	void Awake()
	{
        //GetComponent<ConfigurableJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
        GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
	}
}
