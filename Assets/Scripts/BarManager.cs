using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour {

    public bool Choice = false;
    private float Cur, Max;
    public float width, height;
    public GameObject Ting;
    // Use this for initialization
    void Start() {
        Ting = GameObject.FindGameObjectWithTag("Ship");
    }

    // Update is called once per frame
    void Update() {
        if (Choice)
        {
            Max = Ting.GetComponent<ShipBallaster>().MaxHp;
            Cur = Ting.GetComponent<ShipBallaster>().currentHp;
        }
        else
        {
            Max = Ting.GetComponent<Swimming>().maxPetrol;
            Cur = Ting.GetComponent<Swimming>().currentPetrol;
        }
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width * (Cur / Max), height);
    }
}
