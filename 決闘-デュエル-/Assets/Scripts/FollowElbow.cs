using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowElbow : MonoBehaviour {

    private GameObject hand;

	// Use this for initialization
	void Start () {
        hand = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = hand.transform.rotation;
	}
}
