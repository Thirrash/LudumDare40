using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManager : MonoBehaviour
{
    public static HookManager Instance;
    public List<ChainShoot> chains = new List<ChainShoot>();
    public List<bool> readiness = new List<bool>(4);

    public void SetReadiness(ChainShoot chain) {
        int index = chains.IndexOf(chain);
        readiness[index] = true;
    }

    void Awake() {
        Instance = this;
    }

    void Start() {

    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            int index = -1;
            for (int i = 0; i < readiness.Count; i++) {
                if (readiness[i] == false) {
                    index = i;
                    break;
                }
            }

            if (index != -1) {
                chains[index].Shoot();
            }
        }
    }
}
