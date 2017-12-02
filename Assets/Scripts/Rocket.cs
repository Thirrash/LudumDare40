using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float damage = 4.0f;
    public float explosionRange = 3.0f;
    public GameObject explosion;
    public GameObject model;
    public GameObject blink;
    private Rigidbody rigid;
    private bool bHasCollided = false;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9 && !bHasCollided)
            Blow();
    }

    private void Blow() {
        blink.SetActive(true);
        model.SetActive(false);
        Destroy(rigid);
        bHasCollided = true;
        Destroy(GetComponent<FollowShip>());
        explosion.SetActive(true);

        Collider[] floaters = Physics.OverlapSphere(transform.position, explosionRange, 1 << 9, QueryTriggerInteraction.Collide);
        foreach (Collider c in floaters) {
            float dist = (c.transform.position - transform.position).magnitude;
            Ballast bal = c.GetComponent<Ballast>();
            if (bal != null)
                bal.CurrentHp -= damage * dist / explosionRange;

            ShipBallaster shipBal = c.GetComponent<ShipBallaster>();
            if (shipBal != null) {
                shipBal.CurrentHp -= damage * Mathf.Clamp(dist / explosionRange, 0.0f, 1.0f);
            }
            Debug.Log(c.gameObject.name + "|" + (damage * dist / explosionRange));
        }

        StartCoroutine(Blink());
        StartCoroutine(Destruction());
    }
    
    private IEnumerator Destruction() {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    private IEnumerator Blink()
    {
        yield return new WaitForSeconds(1.0f);
        blink.SetActive(false);
    }
}
