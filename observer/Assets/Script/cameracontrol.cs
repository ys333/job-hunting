using UnityEngine;
using System.Collections;

public class cameracontrol : MonoBehaviour {
    public bool cameraon = false;
    Camera mainCamera;
    Camera thisCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        foreach (Transform child in transform)
        {
            if (child.tag == "hacCamera")
            {
                //targetはGameObject型
                GameObject _child = child.gameObject;
                _child = transform.FindChild("hacCamera").gameObject;
                thisCamera = _child.GetComponent<Camera>();
            }
        }
	}
	// Update is called once per frame
	void Update () {
	    if (cameraon == true){
            mainCamera.enabled = false;
            thisCamera.enabled = true;
        }
	}
}
