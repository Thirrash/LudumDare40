using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    public Ballast ballast;
    public Color NormalCOlor;
    public Color StatDamaged;
    public Color EndDamaged;
    private UnityEngine.UI.Image image;

    private void Awake() {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    void Start() {
        ballast.OnHpChanged += OnChange;
        image.color = NormalCOlor;
    }

    private void OnChange(float ratio) {
        if (ratio == 1.0f) {
            image.color = NormalCOlor;
        } else {
            image.color = Color.Lerp(StatDamaged, EndDamaged, 1.0f - ratio);
        }
    }
}
