using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballast : MonoBehaviour
{
    public event System.Action<float> OnHpChanged;

    public float MaxRotX = 0.0f;
    public float MaxRotZ = 0.0f;
    public float Mass = 1.0f;
    public float MaxHp = 10.0f;
    public float CurrentHp {
        get { return currentHp; }
        set {
            currentHp = value;
            if (currentHp < 0.0f) {
                currentHp = 0.0f;
                GetComponent<Collider>().enabled = false;
            } else {
                if (GetComponent<Collider>().enabled == false) {
                    GetComponent<Collider>().enabled = true;
                }
            }

            OnHpChanged.Invoke(currentHp / MaxHp);
        }
    }

    private Rigidbody rigidbody;
    [SerializeField] private float currentHp;

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
