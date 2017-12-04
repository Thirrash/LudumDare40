using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBody : MonoBehaviour
{
    public GameObject Body;
    public GameObject Wagon;
    public Vector3 StartPos;
    public float Time = 3.0f;
    public float TimeWagon = 8.0f;

    void Start() {
        InvokeRepeating("Spawn", 0.0f, Time);
        InvokeRepeating("SpawnWagon", 2.0f, TimeWagon);
    }


    private void Spawn() {
        Vector3 offset = new Vector3(Random.Range(-15.0f, 15.0f), 0.0f, Random.Range(-15.0f, 15.0f));
        Instantiate(Body, StartPos + offset, Quaternion.identity);
    }

    private void SpawnWagon() {
        Vector3 offset = new Vector3(Random.Range(-15.0f, 15.0f), 0.0f, Random.Range(-15.0f, 15.0f));
        Instantiate(Wagon, StartPos + offset, Quaternion.identity);
    }
}
