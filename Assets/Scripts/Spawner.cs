using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    public float maxHighOffset;
    public float minHighOffset;
    public GameObject Teren;
    public GameObject Ting;
    private GameObject Ship;
    private Terrain ter;
    private float hardness=1;
    private List<GameObject> tings = new List<GameObject>();
    int size = 0;
    public int differ = 3;
    private float[] points = new float[2];
    // Use this for initialization

    private float minx, minz, maxx, maxz;
    void Start () {
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
        hardness = Ship.GetComponent<GetStuffOnTheShip>().Points+1;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag(Ting.tag))
        {
            tings.Add(g);
        }
        while (tings.Count < differ* hardness)
        {
            Instantiate(Ting, new Vector3(Random.Range(minx,maxx),ter.transform.position.y+Random.Range(minHighOffset, maxHighOffset), Random.Range(minz, maxz)), Quaternion.identity);
            break;
        }
        while (tings.Count > differ * hardness)
        {
            Destroy(GameObject.FindWithTag(Ting.tag));
            break;
        }
        tings.Clear();
    }
}
