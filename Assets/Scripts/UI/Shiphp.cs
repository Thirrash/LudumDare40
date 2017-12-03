using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shiphp : MonoBehaviour
{
    public ShipBallaster Ship;
    private Image image;
    private Text text;

    // Use this for initialization
    void Start() {
        Ship.OnHpChanged += OnChange;
        OnChange();
    }

    private void OnChange(float Value) {
        image.fillAmount = 
    }
}
