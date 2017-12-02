using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ShipObj;
    private Vector3 Offset;

    void Start() {
        Offset = transform.position - ShipObj.transform.position;
    }

    void Update() {
        transform.position = ShipObj.transform.position + Offset;
    }
}
