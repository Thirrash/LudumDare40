using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float damage = 8.0f;
    public float explosionRange = 3.0f;
    public float speed = 0.1f;
    public GameObject explosion;
    public GameObject model;
    public GameObject blink;
    private Rigidbody rigid;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start() {
        rigid.velocity = new Vector3(speed, 0.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9)
            Blow();
    }

    private void Blow() {
        blink.SetActive(true);
        model.SetActive(false);
        rigid.velocity = Vector3.zero;
        explosion.SetActive(true);

        Collider[] floaters = Physics.OverlapSphere(transform.position, explosionRange, 1 << 9, QueryTriggerInteraction.Collide);
        foreach (Collider c in floaters) {
            float dist = (c.transform.position - transform.position).magnitude;
            c.GetComponent<Ballast>().CurrentHp -= damage * dist / explosionRange;
        }

        StartCoroutine(Blink());
        StartCoroutine(Destruction());
    }
    
    private IEnumerator Destruction() {
        yield return new WaitForSeconds(6.0f);
        Destroy(gameObject);
    }

    private IEnumerator Blink()
    {
        yield return new WaitForSeconds(1.0f);
        blink.SetActive(false);
    }
}
