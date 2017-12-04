using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusHit : MonoBehaviour {
    public GameObject Mesh;
    public ParticleSystem Particle;
    public float Time = 5.0f;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ship") {
            Particle.Play();
            Mesh.SetActive(false);
            Destroy(gameObject, Time);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
