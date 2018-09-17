using UnityEngine;
using System.Collections;

public class call : MonoBehaviour {
    public PhoneCall Call;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);
        if (col.gameObject.tag == "Player")
        {
            Call.OnPause();
            Destroy(gameObject);
        }
    }
}
