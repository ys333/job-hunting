using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMoveChecker : MonoBehaviour {

    private bool isDo = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.name == "Bullet")
    //    {
    //        if (!isDo)
    //        {
    //            isDo = other.GetComponent<Bullet>().IsMine;
    //            GameObject.Find("TitleController").GetComponent<TitleController>().PassLoadNextScene(isDo);
    //        }
    //    }
    //}

    public void HitBullet(bool isMine)
    {
        Debug.Log("jhgffffffffffffffffffffffffffffffff");
        if (!isDo)
        {
            isDo = isMine;
            GameObject.Find("TitleController").GetComponent<TitleController>().PassLoadNextScene(isDo);
            Debug.Log(isMine);

        }
    }

}
