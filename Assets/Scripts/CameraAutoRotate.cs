using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoRotate : MonoBehaviour
{
    public float Distance = 30.0f;
    public float speed = 20.0f;
    private float angle = 0.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float xOffset = Distance * Mathf.Sin(Time.time * speed);
        float zOffset = Distance * Mathf.Cos(Time.time * speed);
        transform.position = new Vector3(219.0f, 34.0f, 223.0f) + new Vector3(xOffset, 0.0f, zOffset);
        transform.LookAt(new Vector3(219.0f, 14.0f, 223.0f));
    }
}
