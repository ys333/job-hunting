using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLocalIK : MonoBehaviour {
    private Transform[] IK = new Transform[3];
	// Use this for initialization
	void Start () {
        IK[0] = GameObject.Find("MyHead").GetComponent<Transform>();
        IK[1] = GameObject.Find("MyHand_L").GetComponent<Transform>();
        IK[2] = GameObject.Find("MyHand_R").GetComponent<Transform>();

        IK[0].transform.parent = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").transform;
        IK[1].transform.parent = GameObject.Find("LocalAvatar(Clone)/hand_left").transform;
        IK[2].transform.parent = GameObject.Find("LocalAvatar(Clone)/hand_right").transform;

        for (int i = 0; i < IK.Length; i++)
        {
            IK[i].transform.localPosition = Vector3.zero;
            IK[i].transform.localRotation = Quaternion.identity;
            IK[i].transform.localScale = Vector3.one;

        }
        IK[1].transform.localRotation = Quaternion.Euler(new Vector3(-90.0f, 90.0f, 0.0f));
        IK[2].transform.localRotation = Quaternion.Euler(new Vector3(-90.0f, -90.0f, 0.0f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
