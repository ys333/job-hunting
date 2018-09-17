using UnityEngine;
using System.Collections;

public class hellcameracousetu : MonoBehaviour {
	public Transform maincamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.localEulerAngles = maincamera.localEulerAngles;
	}
}
