using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballast : MonoBehaviour
{
    public float MaxRotX = 0.0f;
    public float MaxRotZ = 0.0f;
    public float Mass = 1.0f;
    public float MaxHp = 10.0f;
    public float CurrentHp;
    private Rigidbody rigidbody;

    public Vector3 GetRotation() {
        return new Vector3(MaxRotX * (1.0f - CurrentHp / MaxHp), 0.0f, MaxRotZ * (1.0f - CurrentHp / MaxHp));
    }

    void Start() {
        CurrentHp = MaxHp;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        //rigidbody.AddForce(transform.up, ForceMode.Force);
    }
}
