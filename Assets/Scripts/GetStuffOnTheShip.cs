using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStuffOnTheShip : MonoBehaviour
{
    public event System.Action<float> OnMoneyChange;
    public float Points {
        get {
            return points;
        } set {
            points = value;
            if (OnMoneyChange != null)
                OnMoneyChange.Invoke(points);
        }
    }
    public float PointsPerHp = 0.01f;
    public float PointsPerFuel = 0.0001f;
    public float PointsPerTreasure = 1.0f;
    public float BombThreshold = 1.0f;

    private float points = 0.0f;

    public void OnTrigger(Swimming Swi, ShipBallaster Bal) {
        foreach (ChainShoot c in HookManager.Instance.chains) {
            if (c.bPicked) {
                Points += PointsPerTreasure;
                c.bPicked = false;
                c.DestroyChain();
                HookManager.Instance.readiness[HookManager.Instance.chains.IndexOf(c)] = false;
            }
        }

        Points = Bal.Repair(Points / PointsPerHp) * PointsPerHp;
        if (Points < (Swi.maxPetrol - Swi.CurrentPetrol) * PointsPerFuel) {
            Swi.CurrentPetrol += Points / PointsPerFuel;
            Points = 0.0f;
        } else {
            Points -= (Swi.maxPetrol - Swi.CurrentPetrol) * PointsPerFuel;
            Swi.CurrentPetrol = Swi.maxPetrol;
        }
    }

    void Start() {

    }

    void Update() {

    }

    private void OnTriggerEnter(Collider other) {

    }
}
