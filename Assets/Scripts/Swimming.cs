using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    public float currentPetrol;
    public float maxPetrol = 1000;
    public float sila;
    public float force = 1.0f;
    public float forceUp = 0.005f;
    public float torqueSide = 0.005f;
    private Rigidbody rigid;
    private ShipBallaster bal;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
        bal = GetComponent<ShipBallaster>();
        currentPetrol = maxPetrol;
    }

    void Update() {
        if (currentPetrol>0)
        {
            sila = (bal.CurrentHp / bal.MaxHp) * force;
            if (Input.GetKey(KeyCode.W)) {
                rigid.AddForce(-transform.forward * sila);
                currentPetrol -= Time.deltaTime * 2;
            }
            if (Input.GetKey(KeyCode.S)) {
                rigid.AddForce(transform.forward * sila);
                currentPetrol -= Time.deltaTime * 2;
            }
            if (Input.GetKey(KeyCode.A)) {
                rigid.AddTorque(-Vector3.up * (bal.CurrentHp / bal.MaxHp) * torqueSide);
                currentPetrol -= Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D)) {
                rigid.AddTorque(Vector3.up * (bal.CurrentHp / bal.MaxHp) * torqueSide);
                currentPetrol -= Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Space)) {
                rigid.AddForce(Vector3.up * (bal.CurrentHp / bal.MaxHp) * forceUp);
                currentPetrol -= Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftShift)) {
                rigid.AddForce(-Vector3.up * (bal.CurrentHp / bal.MaxHp) * forceUp);
                currentPetrol -= Time.deltaTime;
            }
        }

        //rigid.rotation = Quaternion.Euler(rigid.rotation.eulerAngles.x, rigid.rotation.eulerAngles.y, 0.0f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Transport") {
            other.GetComponent<GetStuffOnTheShip>().OnTrigger(this, bal);
        }
    }
}
