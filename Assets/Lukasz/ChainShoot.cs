using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainShoot : MonoBehaviour {

    public GameObject ProjectileTemplate;

    public Vector3 Target;
    public float ForceValue;
    public float Drag;
    public float PullForceValue;

    private GameObject projectile;
    private Vector3 forceVector;
    private bool treasureHeld;
    private bool loaded = true;

    void Start ()
    {
        projectile = GameObject.Instantiate(ProjectileTemplate);
        projectile.GetComponent<HookTrigger>().OnTreasureGrabbedEvent += (GameObject o) => { treasureHeld = true; };
        projectile.transform.position = transform.position;
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.drag = Drag;
    }
	
    void Shoot()
    {
        forceVector = Vector3.Normalize(Target) * ForceValue;
        projectile.GetComponent<Rigidbody>().AddForce(forceVector);
        loaded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("chuj");
        if(other.gameObject == projectile)
        {
            Debug.Log("XD");
            loaded = true;
        }
    }

	void Update ()
    {
        var mouseWheelDir = Input.GetAxis("Mouse ScrollWheel");
        if(mouseWheelDir < 0)
        {
            Vector3 toBase = transform.position - projectile.transform.position;
            toBase = Vector3.Normalize(toBase);
            projectile.GetComponent<Rigidbody>().AddForce(toBase * PullForceValue);
        }
        if(loaded && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

}
