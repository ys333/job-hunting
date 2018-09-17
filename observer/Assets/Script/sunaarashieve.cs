using UnityEngine;
using System.Collections;

public class sunaarashieve : MonoBehaviour {
	public GameObject sunaplane;
	public Material sunatex;
	public bool mode = false;
	bool rota;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mode) {
			switch(rota){
			case true:
				transform.rotation = Quaternion.Euler (90, 90, -90);
				rota = false;
				break;
			case false:
				transform.rotation = Quaternion.Euler (-90, -90,90);
				rota = true;
				break;
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if(sunaplane){
			if (col.gameObject.tag == "Player"){
				sunaplane.AddComponent<sunaarashieve> ().mode=true;
				sunaplane.GetComponent<Renderer> ().material = sunatex;
				sunaplane.GetComponent<AudioSource> ().Play();
				Destroy (gameObject);
			}
		}
	}
}
