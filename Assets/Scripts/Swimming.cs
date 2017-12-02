using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    public float force = 1.0f;
    public float torqueUp = 0.005f;
    public float torqueSide = 0.005f;
    private Rigidbody rigid;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            rigid.AddForce(transform.forward * force);
        }
        if (Input.GetKey(KeyCode.S)) {
            rigid.AddForce(-transform.forward * force);
        }
        if (Input.GetKey(KeyCode.A)) {
            rigid.AddTorque(-transform.up * torqueSide);
        }
        if (Input.GetKey(KeyCode.D)) {
            rigid.AddTorque(transform.up * torqueSide);
        }
        if (Input.GetKey(KeyCode.Space)) {
            rigid.AddTorque(-transform.right * torqueUp);
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            rigid.AddTorque(transform.right * torqueUp);
        }
        if (Input.GetKey(KeyCode.Q)) {
            rigid.AddTorque(transform.forward * torqueUp);
        }
        if (Input.GetKey(KeyCode.E)) {
            rigid.AddTorque(-transform.forward * torqueUp);
        }

        //rigid.rotation = Quaternion.Euler(rigid.rotation.eulerAngles.x, rigid.rotation.eulerAngles.y, 0.0f);
    }
}
