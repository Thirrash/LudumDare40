using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shiphp : MonoBehaviour
{
    public GetStuffOnTheShip Money;
    public ShipBallaster Ship;
    public Swimming Swim;

    public Image image;
    public Text text;
    public Image petrolImage;
    public Text petrolText;
    public Text moneyText;

    public List<Image> BombsImages = new List<Image>(10);
    public Color Inactive;
    public Color Active;
    private float prevValue = 0.0f;

    // Use this for initialization
    void Start() {
        Ship.OnHpChanged += OnChange;
        Swim.OnPetrolChange += OnChangePetrol;
        Money.OnMoneyChange += OnChangeMoney;
        OnChange(Ship.CurrentHp);
    }

    private void OnChange(float Value) {
        image.fillAmount = Value / Ship.MaxHp;
        text.text = Value.ToString("F0") + " / " + Ship.MaxHp.ToString("F0");
    }

    private void OnChangePetrol(float Value) {
        petrolImage.fillAmount = Value / Swim.maxPetrol;
        petrolText.text = Value.ToString("F0") + " / " + Swim.maxPetrol.ToString("F0");
    }

    private void OnChangeMoney(float Value) {
        int prev = (int)(prevValue / Money.BombThreshold);
        int curr = (int)(Value / Money.BombThreshold);
        if (prev != curr) {
            for (int i = 0; i < prev; i++) {
                BombsImages[i].color = Inactive;
            }

            for (int i = 0; i < curr; i++) {
                BombsImages[i].color = Active;
            }
        }

        moneyText.text = (Value * 1000.0f).ToString("F0") + " $";
    }
}
