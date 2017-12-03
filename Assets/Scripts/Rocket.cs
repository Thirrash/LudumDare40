using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public bool typ;
    public bool dg = false;
    public float damage = 4.0f;
    public float explosionRange = 3.0f;
    public GameObject explosion;
    public GameObject model;
    public static GameObject blink;
    private Rigidbody rigid;
    private bool bHasCollided = false;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start() {
        dg = false;
        blink = GameObject.FindGameObjectWithTag("Blink");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9 && !bHasCollided)
            Blow();
    }

    private void Blow() {
        if(typ)
            model.SetActive(false);
        Destroy(rigid);
        bHasCollided = true;
        Destroy(GetComponent<FollowShip>());
        explosion.SetActive(true);

        Collider[] floaters = Physics.OverlapSphere(transform.position, explosionRange, 1 << 9, QueryTriggerInteraction.Collide);
        foreach (Collider c in floaters) {
            dg = true;
            float dist = (c.transform.position - transform.position).magnitude;
            float dmg = Mathf.Clamp(dist / explosionRange, 0.0f, 1.0f);

            Ballast bal = c.GetComponent<Ballast>();
            if (bal != null) {
                bal.CurrentHp -= damage * dmg * dmg;
                Debug.Log("Ballast: " + (damage * dmg * dmg));
            }

            ShipBallaster shipBal = c.GetComponent<ShipBallaster>();
            if (shipBal != null) {
                shipBal.CurrentHp -= damage * (1.0f - shipBal.sumCurrHp / shipBal.sumMaxHp) * (1.0f - shipBal.sumCurrHp / shipBal.sumMaxHp);
                Debug.Log("ShipBal damage: " + (damage * (1.0f - shipBal.sumCurrHp / shipBal.sumMaxHp) * (1.0f - shipBal.sumCurrHp / shipBal.sumMaxHp)));
            }
        }

        StartCoroutine(Blink());
        StartCoroutine(Destruction());
    }
    private IEnumerator Blink()
    {
        if(dg)
            blink.GetComponent<RawImage>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(1.0f);

    }
    private IEnumerator Destruction() {
        float time = 0.0f;
        while (time < 2.0f) {
            if(dg)
                blink.GetComponent<RawImage>().color = new Color(255, 255, 255, (1.0f - time / 2.0f));
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
