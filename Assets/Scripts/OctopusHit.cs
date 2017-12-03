using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusHit : MonoBehaviour {
    public GameObject Ink;
    private void Start()
    {
        Ink.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Ink.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Ink.SetActive(false);
    }
}
