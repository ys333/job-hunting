using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class camerahac : MonoBehaviour
{
    /// <summary>
    /// カメラをタッチしたかの判定のスクリプト
    /// </summary>
    GameObject target;
    stickset stick;
    Camerakirikae camerakirikae;
    public float cameracode = 0;
    public GameObject obj2;
    Ray ray;
    public Material lightmaterial;
    string rayobj;
    public bool cameraon = false;
    public ligahtcolor setlighatcolor;
    public enum ligahtcolor{
        non,
        nomal,
        alert
    }
    void Start()
    {
        stick = GameObject.Find("MobileSingleStickControl").GetComponent<stickset>();
    }
    void Update()
    {
        camerakirikae = obj2.GetComponent<Camerakirikae>();
        if (Input.GetMouseButtonDown(0))
        {
            if (camerakirikae.Playermode)
            {
                //プレイヤーカメラからの判定取得
                ray = camerakirikae.mainCamera.ScreenPointToRay(Input.mousePosition);
            }
            else
            {
                //監視カメラからの判定取得
                ray = camerakirikae.HacCamera.ScreenPointToRay(Input.mousePosition);
            }
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                rayobj = hit.collider.gameObject.ToString();
                GameObject obj = hit.collider.gameObject;
                if (obj == gameObject)
                {
                    cameraon = true;
                    stick.ok = false;
                    if (cameracode == 0)
                    {
                        Renderer ligatgrean = transform.FindChild("light").GetComponent<Renderer>();
                        ligatgrean.material = lightmaterial;
                        Light pligat = transform.FindChild("light/Point light").gameObject.GetComponent<Light>();
                        switch (setlighatcolor){
                            case ligahtcolor.nomal:
                                pligat.color = Color.green;
                                break;
                            case ligahtcolor.alert:
                                pligat.color = Color.red;
                                break;
                        }
                        //初めて自分がタッチされたとき
                        //カメラの向きによりカメラモードの変更を可能にする
                        Screen.autorotateToLandscapeRight = true;
                        Screen.autorotateToLandscapeLeft = true;
                        int i = 0;
                        while (camerakirikae.cameras[i] != null)
                        {
                            if (camerakirikae.cameras[i] == gameObject)
                            {
                                i = -1;
                                break;
                            }
                            i++;
                        }
                        if (i != -1)
                        {
                            //camerakirikaeのスクリプトに
                            //新しいカメラの情報を入れる
                            camerakirikae.cameras[i] = gameObject;
                        }
                    }
                }
            }
        }
    }
    void OnGUI()//確認用デバッグGUI
    {
        //GUI.Label(new Rect(20, 200, 100, 50), rayobj);

    }
}
