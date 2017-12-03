using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSpawner : MonoBehaviour {

    public GameObject ChainHead;
    public GameObject ChainGuide;
    public GameObject ChainElementTemplate;
    public float Distance = 1;
    public int MaxCount;

    private List<GameObject> chainElements = new List<GameObject>();
    private GameObject lastChainElement;

	// Use this for initialization
	void Start () {

        //Test
        ChainHead.GetComponent<Rigidbody>().AddForce(new Vector3(10000, 0, 0));
        //----

        ChainHead.GetComponent<CharacterJoint>().connectedBody = ChainGuide.GetComponent<Rigidbody>();
        chainElements.Add(ChainHead);
        lastChainElement = ChainHead;
	}
	
	// Update is called once per frame
	void Update () {
        if(chainElements.Count <= MaxCount)
        {
		    while(Vector3.Distance(ChainGuide.transform.position, transform.position) > Distance)
            {
                Debug.Log("chuj");
                GameObject newChainElement = Instantiate(ChainElementTemplate);
                newChainElement.transform.position = ChainGuide.transform.position;

                chainElements.Add(newChainElement);
                Vector3 toSource = Vector3.Normalize(transform.position - ChainGuide.transform.position);
                toSource *= Distance;
                ChainGuide.transform.position += toSource;

                //lastChainElement.transform.SetParent(newChainElement.transform);
                lastChainElement.GetComponent<CharacterJoint>().connectedBody = newChainElement.GetComponent<Rigidbody>();
                newChainElement.GetComponent<CharacterJoint>().connectedBody = ChainGuide.GetComponent<Rigidbody>();

                lastChainElement = newChainElement;
            }
        }
        else
        {
            ChainGuide.GetComponent<Rigidbody>().isKinematic = true;
        }
	}
}
