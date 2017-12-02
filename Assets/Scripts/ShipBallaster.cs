using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBallaster : MonoBehaviour
{
    public float MaxDrownSpeed = 0.5f;
    public float RotateRate = 0.4f;
    public float Length = 5.0f;
    public Rigidbody rigidbody;
    public GameObject ballastObj;
    private List<Ballast> ballasts = new List<Ballast>();
    private float massSum = 0.0f;
    private Quaternion prevRotation = Quaternion.identity;
    private Quaternion goal;
    private float sumCurrHp = 0.0f;
    private float sumMaxHp = 0.0f;

    public float MaxHp = 100.0f;
    public float CurrentHp {
        get { return currentHp; }
        set {
            currentHp = value;
            if (currentHp < 0.0f) {
                currentHp = 0.0f;
                GetComponent<Collider>().enabled = false;
            }
        }
    }
    [SerializeField] private float currentHp;

    void Start() {
        CurrentHp = MaxHp;
        rigidbody = GetComponent<Rigidbody>();
        Vector3 newCenter = Vector3.zero;
        foreach (Ballast b in ballastObj.GetComponentsInChildren<Ballast>()) {
            ballasts.Add(b);
            sumMaxHp += b.MaxHp;
        }

        float sumAbsZ = 0.0f;
        foreach (Ballast b in ballasts) {
            b.MaxRotZ = 90.0f *
                ((b.transform.position.x > transform.position.x) ? -1.0f : 1.0f) /
                (float)(ballasts.Count / 2);
            sumAbsZ += Mathf.Abs(b.transform.localPosition.z);
        }

        foreach (Ballast b in ballasts) {
            b.MaxRotX = 180.0f *
                ((b.transform.position.z > transform.position.z) ? 1.0f : -1.0f) *
                Mathf.Abs(b.transform.localPosition.z) / sumAbsZ;
        }
    }

    void Update() {
        Vector3 total = Vector3.zero;
        sumCurrHp = 0.0f;
        foreach (Ballast b in ballasts) {
            total += new Vector3(b.MaxRotX * (1.0f - b.CurrentHp / b.MaxHp), 0.0f, b.MaxRotZ * (1.0f - b.CurrentHp / b.MaxHp));
            sumCurrHp += b.CurrentHp;
        }

        float multiplier = ((sumMaxHp - sumCurrHp) * (sumMaxHp - sumCurrHp) / sumMaxHp / sumMaxHp);
        total *= multiplier;
        goal = Quaternion.Euler(0.0f, rigidbody.rotation.eulerAngles.y, 0.0f) * Quaternion.Euler(total);

        rigidbody.MoveRotation(Quaternion.RotateTowards(rigidbody.rotation, goal, RotateRate));
        prevRotation = rigidbody.rotation;

        rigidbody.MovePosition(rigidbody.position - Vector3.up * MaxDrownSpeed * multiplier);
    }
}
