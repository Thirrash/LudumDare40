﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainShoot : MonoBehaviour
{
    public Vector3 SpawnLoc;
    public GameObject Prefab;
    public GameObject ProjectileTemplate;
    public bool bPicked = false;

    public Vector3 Target;
    public float ForceValue;
    public float Drag;
    public float PullForceValue;

    private GameObject projectile;
    private Vector3 forceVector;
    private bool treasureHeld = false;
    private bool loaded = true;
    public Coroutine routine = null;
    private List<GameObject> chains = new List<GameObject>();

    public void DestroyChain() {
        foreach (GameObject g in chains) {
            Destroy(g);
        }

        chains.Clear();
    }

    public void Shoot() {
        if (!bPicked) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000, 1 << 12)) {
                if (routine == null)
                    routine = StartCoroutine(ShootChain(hit.point - transform.position, () => { return bPicked; }));
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == projectile) {
            Destroy(projectile);
            loaded = true;
        }
    }

    private IEnumerator ShootChain(Vector3 aDirection, System.Func<bool> bPickedWrapper) {
        chains.Clear();

        ProjectileTemplate = GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.Euler(180.0f, 90.0f, 0.0f), transform.parent);
        ProjectileTemplate.transform.localPosition = SpawnLoc;
        ProjectileTemplate.GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
        chains.Add(ProjectileTemplate);
        GameObject current = ProjectileTemplate;
        while (current.transform.childCount > 0) {
            GameObject child = current.transform.GetChild(0).gameObject;
            chains.Add(child.gameObject);
            current = child;
        }

        for (int i = chains.Count - 1; i >= 0; i--) {
            chains[i].GetComponent<HookTrigger>().chainer = this;
            chains[i].GetComponent<MeshRenderer>().enabled = (false);
        }

        int count = 0;
        current = ProjectileTemplate;
        current.GetComponent<MeshRenderer>().enabled = (true);
        while (current != null && current.transform.childCount > 0) {
            GameObject next = current.transform.GetChild(0).gameObject;
            next.GetComponent<MeshRenderer>().enabled = (true);

            if (next.GetComponent<HookTrigger>() == null)
                break;

            next.GetComponent<HookTrigger>().OnTreasureGrabbedEvent += (GameObject o) => { treasureHeld = true; };
            forceVector = Vector3.Normalize(aDirection) * ForceValue;
            next.GetComponent<Rigidbody>().AddForce(forceVector);
            current = next;
            count++;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2.0f);
        if (!bPickedWrapper()) {
            DestroyChain();
        } else {
            HookManager.Instance.SetReadiness(this);
        }

        routine = null;
    }
}
