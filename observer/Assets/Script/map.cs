using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class map : MonoBehaviour {
    public Image[] UI = new Image[3];
    public GameObject[] cameras = new GameObject[6];
    public Camerakirikae ck;
    public GameObject cameraimage;
    public GameObject mapimage;
    Camera thiscamera;
    GameObject[] images = new GameObject[6];
    bool mapactive = false;
    public Text mapbuttonT;
	// Use this for initialization
	void Start () {
        thiscamera=GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Screen.orientation == ScreenOrientation.Portrait&&mapactive) changeplayermode();//縦持ち＝マップを閉じる
	}
    public void mapbutton(){
        switch (mapactive)
        {
            case false:
                mapmode();
                break;
            case true:
                mapclose();
                break;
        }
    }
    void mapmode(){
        mapbuttonT.text = "カメラモード";
        mapactive = true;
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].enabled = false;
        }
        thiscamera.enabled = true;
        for (int i = 0; i < cameras.Length; i++){
            if (cameras[i].GetComponent<camerahac>().cameraon){
                if (images[i] != null) Destroy(images[i]);
                images[i] = Instantiate(cameraimage);
                images[i].transform.parent = mapimage.gameObject.transform;
                images[i].GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, cameras[i].transform.rotation.z);
                images[i].transform.position = thiscamera.WorldToScreenPoint(cameras[i].transform.position);
            }
        }
    }
    void mapclose(){
        mapbuttonT.text = "マップモード";
        mapactive = false;
        for (int i = 0; i < cameras.Length; i++)
        {
            if (images[i] != null) Destroy(images[i]);
        }
        thiscamera.enabled = false;
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].enabled = true;
        }
    }
    void changeplayermode() {
        mapbuttonT.text = "マップモード";
        mapactive = false;
        for (int i = 0; i < cameras.Length; i++)
        {
            if (images[i] != null) Destroy(images[i]);
        }
        thiscamera.enabled = false;
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].enabled = false;
        }
    }
}
