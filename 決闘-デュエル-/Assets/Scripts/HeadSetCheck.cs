using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSetCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //if (OVRManager.isHmdPresent)
        //{
        //    GetComponent<Camera>().enabled = false;
        //}
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRManager.isHmdPresent)
        {
            GetComponent<Camera>().enabled = false;
        }
        else if (!OVRManager.isHmdPresent)
        {
            GetComponent<Camera>().enabled = true;
        }
    }
}
