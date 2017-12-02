using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfNearExplode : MonoBehaviour
{
    public GameObject Ship;
    public GameObject Explosives;
    public float range;
    // Use this for initialization
    void Start()
    {
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
