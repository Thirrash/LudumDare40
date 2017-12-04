using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    public float TimeToDeath = 15.0f;

    // Use this for initialization
    void Start() {
        Destroy(gameObject, TimeToDeath);
    }
}
