using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public float damage = 8.0f;
    public float explosionRange = 3.0f;
    public GameObject explosion;
    public GameObject model;
    public static GameObject blink;
    private Rigidbody rigid;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start() {
        blink = GameObject.FindGameObjectWithTag("Blink");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9)
        {
            
            Blow();
        }
    }

    private void Blow() {
        model.SetActive(false);
        Destroy(rigid);
        Destroy(GetComponent<FollowShip>());
        explosion.SetActive(true);

        Collider[] floaters = Physics.OverlapSphere(transform.position, explosionRange, 1 << 9, QueryTriggerInteraction.Collide);
        foreach (Collider c in floaters) {
            float dist = (c.transform.position - transform.position).magnitude;
            c.GetComponent<Ballast>().CurrentHp -= damage * dist / explosionRange;
            Debug.Log(damage * dist / explosionRange);
            Debug.Log(dist);
        }

        StartCoroutine(Blink());
        StartCoroutine(Destruction());
    }
    private IEnumerator Blink()
    {
        blink.GetComponent<RawImage>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(1.0f);

    }
    private IEnumerator Destruction() {
        yield return new WaitForSeconds(2.0f);
        
        Destroy(gameObject);
        blink.GetComponent<RawImage>().color = new Color(255, 255, 255, 0);
    }
}
