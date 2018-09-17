using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSetmanager : MonoBehaviour {
    [SerializeField]
    private Transform rightHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.transform == rightHand)
        {     
            Debug.Log("Ready??");
        }
    }
}
