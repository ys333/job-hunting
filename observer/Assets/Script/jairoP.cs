using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class jairoP : MonoBehaviour {
    /// <summary>
    /// もう要らない子
    /// </summary>
    public GameObject Object;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = Object.ToString();
        //this.GetComponent<Text>().text = "ぷれいやーもーど" + yoko;
	}
}
