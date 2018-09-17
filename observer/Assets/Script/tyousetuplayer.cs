using UnityEngine;
using System.Collections;

public class tyousetuplayer : MonoBehaviour {
    float objrotate;
	// Use this for initialization
	void Start () {
        objrotate = transform.FindChild("MainCamera").transform.localRotation.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localRotation= Quaternion.Euler(0,objrotate,0);
	}
}
