using UnityEngine;
using System.Collections;

public class dooreve : MonoBehaviour {
    public GameObject door;
    public GameObject oni;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("doorevent");
        }
    }
    IEnumerator doorevent()
    {
        iTween.RotateTo(door, iTween.Hash(
            "y", 180,
            "easeType", iTween.EaseType.linear,"islocal",true
        ));
        yield return new WaitForSeconds(4.5f);
        oni.SetActiveRecursively(false);
        iTween.RotateTo(door, iTween.Hash(
            "y", 93,
            "easeType", iTween.EaseType.linear, "islocal", true
        ));
        Destroy(gameObject);
    }
}
