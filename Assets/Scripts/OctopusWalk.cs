using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusWalk : MonoBehaviour
{
    private List<GameObject> Points = new List<GameObject>();
    public GameObject p;
    public float speed = 0.5f;

    private void Start() {
        GameObject holder = GameObject.FindGameObjectWithTag("Point");
        foreach (Transform g in holder.GetComponentsInChildren<Transform>()) {
            if (g != holder.transform) {
                Points.Add(g.gameObject);
            }
        }

        p = (Points[Random.Range(0, Points.Count - 1)]);
    }

    void Update() {
        float step = speed * Time.deltaTime;
        Vector3 targetDir = (p.transform.position - transform.position).normalized;
        transform.Translate((targetDir) * step);
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);

        if (Vector3.Distance(transform.position, p.transform.position) < 3) {
            p = (Points[Random.Range(0, Points.Count - 1)]);
        }
    }
}
