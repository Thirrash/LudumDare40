using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusWalk : MonoBehaviour {

    private List<GameObject> Octopuses = new List<GameObject>();
    private List<GameObject> Points = new List<GameObject>();
    private List<GameObject> ChoosenOne = new List<GameObject>();
    private List<bool> w = new List<bool>();
    public GameObject octopus;
    public GameObject point;
    public float speed=1;
    bool walking;
    private void Start()
    {
        walking = false;
    }
    // Update is called once per frame
    void Update() {
        if (Octopuses.Count == 0)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag(octopus.tag))
            {
                Octopuses.Add(g);
                w.Add(false);
            }
            foreach(GameObject p in GameObject.FindGameObjectsWithTag(point.tag))
            {
                Points.Add(p);
            }


        }
        bool a = true;

        if (walking)
        {
            float step = speed * Time.deltaTime;
            for (int i = 0; i < Octopuses.Count; i++)
            {
                Vector3 targetDir = ChoosenOne[i].transform.position - transform.position;
                Octopuses[i].transform.Translate((targetDir) * step);
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                Debug.DrawRay(transform.position, newDir, Color.red);
                Octopuses[i].transform.rotation = Quaternion.LookRotation(newDir);
                if (Vector3.Distance(transform.position, ChoosenOne[i].transform.position)<2)
                {
                    w[i] = true;
                }
                else
                {
                    a = false;
                }
            }
            if(a)
            {
                walking = false;
            }
        }
        else
        {
            ChoosenOne.Clear();
            for (int i = 0; i < Octopuses.Count; i++)
            {
                ChoosenOne.Add(Points[Random.Range(0, Points.Count-1)]);
            }
            walking=true;
        }
	}
}
