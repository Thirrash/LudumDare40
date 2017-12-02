using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    public float sila;
    public float force = 1.0f;
    public float forceUp = 0.005f;
    public float torqueSide = 0.005f;
    private Rigidbody rigid;
    private ShipBallaster bal;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
        bal = GetComponent<ShipBallaster>();
    }

    void Update() {
        sila = (bal.CurrentHp / bal.MaxHp) * force;
        if (Input.GetKey(KeyCode.W)) {
            rigid.AddForce(-transform.forward * sila);
        }
        if (Input.GetKey(KeyCode.S)) {
            rigid.AddForce(transform.forward * sila);
        }
        if (Input.GetKey(KeyCode.A)) {
            rigid.AddTorque(-Vector3.up * (bal.CurrentHp / bal.MaxHp) * torqueSide);
        }
        if (Input.GetKey(KeyCode.D)) {
            rigid.AddTorque(Vector3.up * (bal.CurrentHp / bal.MaxHp) * torqueSide);
        }
        if (Input.GetKey(KeyCode.Space)) {
            rigid.AddForce(Vector3.up * (bal.CurrentHp / bal.MaxHp) * forceUp);
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            rigid.AddForce(-Vector3.up * (bal.CurrentHp / bal.MaxHp) * forceUp);
        }

        //rigid.rotation = Quaternion.Euler(rigid.rotation.eulerAngles.x, rigid.rotation.eulerAngles.y, 0.0f);
    }
}
