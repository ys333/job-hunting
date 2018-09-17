using UnityEngine;
using System.Collections;

public class miteru : MonoBehaviour {
    public GameObject kenki;
    public GameObject mayoibi;
	// Use this for initialization
	void Start () {
        switch (Random.Range(0,2))
        {
            case 0:
                kenki.SetActive(true);
                break;
            case 1:
                mayoibi.SetActive(true);
                break;
            default:

                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
