using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusWalk : MonoBehaviour {
    
    private List<GameObject> Points = new List<GameObject>();
    public GameObject p;
    public float speed=0.5f;
    bool walking;
    private void Start()
    {
        walking = false;
    }
    // Update is called once per frame
    void Update() {
        if (Points.Count == 0)
        {
            foreach(GameObject q in GameObject.FindGameObjectsWithTag(p.tag))
            {
                Points.Add(q);
            }
        }

        if (walking)
        {
            float step = speed * Time.deltaTime;
            Vector3 targetDir = p.transform.position - transform.position;
            transform.Translate((targetDir) * step);
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);

            if (Vector3.Distance(transform.position, p.transform.position)<3)
            {
                walking = false;
            }
        }
        else
        {
            p = (Points[Random.Range(0, Points.Count-1)]);
            walking=true;
        }
	}
}
