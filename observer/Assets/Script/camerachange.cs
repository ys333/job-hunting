using UnityEngine;
using System.Collections;
/// <summary>
/// このスクリプトは監視カメラの時に出現するカメラ切り替え用のボタンのスクリプトだぜ。
/// 本題的な処理はcamerakirikaeに任せてるからそっちを見るといいんだぜ。
/// </summary>
public class camerachange : MonoBehaviour {
    public bool nomal = true;
    Camerakirikae camerakirikae;
    public GameObject obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        camerakirikae = obj.GetComponent<Camerakirikae>();
	}

    public void ButtonPush(){
        camerakirikae.hacamera.GetComponent<jairon>().enabled = false;
        camerakirikae.HacCamera.enabled = false;
        if (nomal == true)
        {
            //右のボタン
            camerakirikae.cameracode += 1;
            camerakirikae.changecode = 1;
        }
        else
        {
            //左のボタン
            camerakirikae.cameracode -= 1;
            camerakirikae.changecode = -1;
        }
    }
}
