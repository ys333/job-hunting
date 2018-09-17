using UnityEngine;
using System.Collections;


public class jairon : MonoBehaviour
{
    /// <summary>
    /// スマホの傾きをカメラの向きに反映させる
    /// </summary>
    Camerakirikae camerakirikae;
    private GUIStyle style;
    public Vector3 genkai1;//ここ以上   の範囲で首の周りの限界を設定できる。
    public Vector3 genkai2;//ここ以下   すべて0の場合首の回りの限界は無し（プレイヤー用のカメラなど）になる。
    public Quaternion gyro;
    Quaternion gyrodefo;
    Vector3 gyrosan, ja;
    public float regyrox;
    float gyrosanX, gyrosanY, fgyrox, fgyrox2;
    public bool fast = true;
    bool crick = false;
    // Use this for initialization
    void Start()
    {
        GameObject obj = GameObject.Find("RigidBodyFPSController");
        camerakirikae = obj.GetComponent<Camerakirikae>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(2)){
            camerakirikae.Playermode = !camerakirikae.Playermode;
        }
#elif UNITY_ANDROID

        if (fast)
        {
            fast = false;
            gyrodefo = Input.gyro.attitude;
            gyrodefo = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyrodefo.x, -gyrodefo.y, gyrodefo.z, gyrodefo.w));
            fgyrox2 = gyrodefo.eulerAngles.y;
            fgyrox = transform.eulerAngles.y;
            style = new GUIStyle();
            style.fontSize = 30;
        }

        if (Input.gyro.enabled)
        {
            gyro = Input.gyro.attitude;
            //gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
            //gyro = Quaternion.Euler(0, 0, 0);
            gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
            gyrosan = gyro.eulerAngles;
            gyrosan.y += fgyrox - fgyrox2;
            gyrosan.x -= regyrox;//ここで縦の傾きを調節する
            //カメラの稼動限界を調節する部分
            gyrosanX = (gyrosan.x > 180) ? gyrosan.x - 360 : gyrosan.x;
            gyrosanY = (gyrosan.y > 180) ? gyrosan.y - 360 : gyrosan.y;
            if (genkai1.y != 0 || genkai2.y != 0)
            {
                gyrosan.x = Mathf.Clamp(gyrosanX, genkai1.x, genkai2.x);
            }
            if (genkai1.x != 0 || genkai2.x != 0)
            {
                gyrosan.y = Mathf.Clamp(gyrosanY, genkai1.y, genkai2.y);
            }
            //変更点
            gyrosan.y = (gyrosanY < 0) ? gyrosanY + 360 : gyrosanY;
            gyrosan.x = (gyrosanX < 0) ? gyrosanX + 360 : gyrosanX;
            //変更点ここまで
            //スマホの向きにカメラを傾ける
            gameObject.transform.rotation = Quaternion.Euler(gyrosan);
            if (Screen.orientation == ScreenOrientation.Portrait)
            {
                //縦持ち
                camerakirikae.Playermode = true;
            }
            else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
            {
                //横持ち(左傾け&右傾け)
                camerakirikae.Playermode = false;
            }
        }
        //camera.transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.right) * Input.gyro.attitude * Quaternion.AngleAxis(180.0f, Vector3.forward);
#endif
    }
}

