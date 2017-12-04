using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Parent = null;
    public float maxHighOffset;
    public float minHighOffset;
    public GameObject Teren;
    public GameObject Ting;
    private GameObject Ship;
    private Terrain ter;
    private int hardness = 1;
    private List<GameObject> tings = new List<GameObject>();
    int size = 0;
    public int differ = 3;
    private float[] points = new float[2];
    private float minx, minz, maxx, maxz;

    void Start() {
        Ship = GameObject.FindGameObjectWithTag("Transport");
        Teren = GameObject.FindGameObjectWithTag("Dno");
        ter = Teren.GetComponent<Terrain>();
        minx = ter.transform.position.x;
        minz = ter.transform.position.z;
        maxx = minx + ter.terrainData.size.x;
        maxz = minz + ter.terrainData.size.z;
    }

    // Update is called once per frame
    void Update() {
        hardness = (int)(2 * Ship.GetComponent<GetStuffOnTheShip>().Points) + 1;
        for (int i = 0; i < tings.Count; i++) {
            if (tings[i] == null) {
                float x = Random.Range(minx, maxx);
                float z = Random.Range(minz, maxz);
                tings[i] = Instantiate(Ting, new Vector3(x, ter.SampleHeight(new Vector3(x, 0.0f, z)) + Random.Range(minHighOffset, maxHighOffset), z), Quaternion.identity);
                Debug.Log("xD");
            }
        }

        while (tings.Count < differ * hardness) {
            float x = Random.Range(minx, maxx);
            float z = Random.Range(minz, maxz);
            GameObject go = Instantiate(Ting, new Vector3(x, ter.SampleHeight(new Vector3(x, 0.0f, z)) + Random.Range(minHighOffset, maxHighOffset), z), Quaternion.identity);
            if (Parent != null)
                go.transform.parent = Parent.transform;
            tings.Add(go);
            break;
        }
    }
}
