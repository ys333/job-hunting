using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class nikuhasami : MonoBehaviour {
    GameOver gameover;
    GameObject player;
    public RawImage damage;
    public GameObject maincamera;
    public Image[] image;
    public AudioSource se;
    bool seplay = false;
    public Camera hellcamera;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.tag == "Player")
        {
            if (!seplay)
            {
                seplay = true;
                se.Play();
            }
            col.GetComponent<Camerakirikae>().Playermode = true;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToPortraitUpsideDown = false;
            PlayerPrefs.SetInt("ONISHI", 1);
            player = col.gameObject;
            hellcamera.enabled = true;
            StartCoroutine("dededon");
        }
    }
    IEnumerator dededon()
    {
        for (int i = 0; i<image.Length; i++)
        {
            image[i].enabled = false;
            yield return null;
        }
        player.GetComponent<PLstatus>().enabled = false;
        for (int i = 1; i < 11; i++)
        {
            damage.color = new Color(1, 1, 1, i/10);
            yield return null;
        }
        //ゲームオーバー用のイベント
        
        maincamera.GetComponent<jairon>().enabled = false;
        player.GetComponent<Camerakirikae>().enabled = false;
        StartCoroutine("look");
        for (int i = 0; i < 60; i++)//ボス見つつズームイン
        {
            hellcamera.fieldOfView -= 1f;
            yield return null;
        }
        se.Stop();
        player.GetComponent<GameOver>().enabled = true;
    }
    IEnumerator look()
    {
        bool a = true;
        while (a)
        {
            maincamera.transform.LookAt(gameObject.transform);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
