using UnityEngine;
using System.Collections;

public class kotei : MonoBehaviour {
    /// <summary>
    /// 主人公のモデルが傾かないようにするためのスクリプト
    /// </summary>
	public Transform maincgamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rot = maincgamera.localRotation.eulerAngles;
		rot = new Vector3 (0,rot.y,0);
		gameObject.transform.localRotation = Quaternion.Euler (rot);
    }
}
