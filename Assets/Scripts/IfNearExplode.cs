using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfNearExplode : MonoBehaviour
{
    public float damage = 6.0f;
    public float explosionRange;
    public GameObject Ship;
    public GameObject Explosives;
    public float range;
    // Use this for initialization
    void Start()
    {
        explosionRange = range + 0.2f;
        Ship = GameObject.FindGameObjectWithTag("Ship");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Ship.transform.position, transform.position) < range)
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider[] floaters = Physics.OverlapSphere(transform.position, explosionRange, 1 << 9, QueryTriggerInteraction.Collide);
        foreach (Collider c in floaters)
        {
            float dist = (c.transform.position - transform.position).magnitude;
            float dmg = Mathf.Clamp(dist / explosionRange, 0.0f, 1.0f);

            Ballast bal = c.GetComponent<Ballast>();
            if (bal != null)
            {
                bal.CurrentHp -= damage * dmg * dmg;
                Debug.Log("Ballast: " + (damage * dmg * dmg));
            }

            ShipBallaster shipBal = c.GetComponent<ShipBallaster>();
            if (shipBal != null)
            {
                shipBal.CurrentHp -= damage * (1.0f - shipBal.sumCurrHp / shipBal.sumMaxHp) * (1.0f - shipBal.sumCurrHp / shipBal.sumMaxHp);
                Debug.Log("ShipBal damage: " + (damage * (1.0f - shipBal.sumCurrHp / shipBal.sumMaxHp) * (1.0f - shipBal.sumCurrHp / shipBal.sumMaxHp)));
            }
        }


        Explosives.SetActive(true);
        StartCoroutine(Destruction());
    }

    IEnumerator Destruction()
    {
        float time = 0.0f;
        while (time < 1.0f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
