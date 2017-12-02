using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject RocketPrefab;
    public float SpawnOffset = 2.0f;
    public Vector3[] spawnRange = new Vector3[2];

    void Start() {

    }

    void Update() {

    }

    private IEnumerator Spawn() {
        while (true) {
            yield return new WaitForSeconds(SpawnOffset);
            Vector3 spawnPoint = new Vector3(
                Random.Range(spawnRange[0].x, spawnRange[1].x), 
                Random.Range(spawnRange[0].y, spawnRange[1].y), 
                Random.Range(spawnRange[0].z, spawnRange[1].z)
            );

            GameObject go = GameObject.Instantiate(RocketPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
