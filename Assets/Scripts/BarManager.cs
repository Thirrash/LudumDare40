using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public bool Choice = false;
    private float Cur, Max;
    public float width, height;
    public GameObject Ting;

    void Start() {
        Ting = GameObject.FindGameObjectWithTag("Ship");
    }

    void Update() {
        if (Choice) {
            Max = Ting.GetComponent<ShipBallaster>().MaxHp;
            Cur = Ting.GetComponent<ShipBallaster>().CurrentHp;
        } else {
            Max = Ting.GetComponent<Swimming>().maxPetrol;
            Cur = Ting.GetComponent<Swimming>().CurrentPetrol;
        }
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width * (Cur / Max), height);
    }
}
