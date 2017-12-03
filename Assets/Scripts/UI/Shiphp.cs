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
        OnChange(Ship.CurrentHp);
    }

    private void OnChange(float Value) {
        image.fillAmount = Value / Ship.MaxHp;
        text.text = Value.ToString("F0") + " / " + Ship.MaxHp.ToString("F0");
    }
}
