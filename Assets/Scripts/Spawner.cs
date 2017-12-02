using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    public float highOffset;
    public GameObject Teren;
    public GameObject Ting;
    private Terrain ter;
    private float hardness=1;
    int size = 0;
    public int differ = 3;
    private float[] points = new float[2];
    // Use this for initialization

    private float minx, minz, maxx, maxz;
    void Start () {
        Teren = GameObject.FindGameObjectWithTag("Dno");
        ter = Teren.GetComponent<Terrain>();

        minx = ter.transform.position.x;
        minz = ter.transform.position.z;
        maxx = minx + ter.terrainData.size.x;
        maxz = minz + ter.terrainData.size.z;
    }
	
	// Update is called once per frame
	void Update () {
        while (size < differ* hardness)
        {
            size++;
            Instantiate(Ting, new Vector3(Random.Range(minx,maxx),ter.transform.position.y+highOffset, Random.Range(minz, maxz)), Quaternion.identity);
            break;
        }
        while (size > differ * hardness)
        {
            size--;
            Destroy(GameObject.FindWithTag(Ting.tag));
            break;
        }
    }
}
