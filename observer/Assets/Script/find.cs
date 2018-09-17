using UnityEngine;
using System.Collections;

public class find : MonoBehaviour
{
    GameObject enemy;
    public bool sound =false;
    Mayoibi mayoibi;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        GameObject enemy = gameObject.transform.parent.gameObject;
        mayoibi = enemy.GetComponent<Mayoibi>();
        player = GameObject.Find("RigidBodyFPSController");
    }

    // Update is called once per frame
    void Update()
    {
    }
    //GameObject TragetObject = GameObject.FindGameObjectWithTag ("Player");
    void OnTriggerEnter(Collider col){
        if (col.tag == "Player" && !mayoibi.captureMode)
        {
            if (!sound)
            {
                sound = true;
                player.GetComponents<AudioSource>()[0].Play();
            }
        }
    }
}
