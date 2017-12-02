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
    private bool treasureHeld = false;
    private bool loaded = true;

    void Start ()
    {
    }
	
    void Shoot(Vector3 aDirection)
    {
        projectile = Instantiate(ProjectileTemplate);
        projectile.transform.position = transform.position - new Vector3(0, 5, 0);
        projectile.GetComponent<Rigidbody>().drag = Drag;
        projectile.GetComponent<HookTrigger>().OnTreasureGrabbedEvent += (GameObject o) => { treasureHeld = true; };

        forceVector = Vector3.Normalize(aDirection) * ForceValue;
        projectile.GetComponent<Rigidbody>().AddForce(forceVector);
        loaded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == projectile)
        {
            Destroy(projectile);
            loaded = true;
        }
    }

	void Update ()
    {
        var mouseWheelDir = Input.GetAxis("Mouse ScrollWheel");
        if(!loaded && mouseWheelDir < 0)
        {
            Vector3 toBase = transform.position - projectile.transform.position;
            toBase = Vector3.Normalize(toBase);
            projectile.GetComponent<Rigidbody>().AddForce(toBase * PullForceValue);
        }
        if(loaded && Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Shoot(hit.point-transform.position);
            }
        }
    }

}
