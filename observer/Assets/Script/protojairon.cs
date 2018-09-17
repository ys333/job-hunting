using UnityEngine;
using System.Collections;


public class protojairon : MonoBehaviour
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
    float gyrosanX, gyrosanY;
    // Use this for initialization
    void Start()
    {
        //camera = gameObject;
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        style = new GUIStyle();
        style.fontSize = 30;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("RigidBodyFPSController");
        if (obj != null)
        {
            camerakirikae = obj.GetComponent<Camerakirikae>();
        }
        if (Input.gyro.enabled)
        {
            gyro = Input.gyro.attitude;
            //gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
            //gyro = Quaternion.Euler(0, 0, 0);
            gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
            gyrosan = gyro.eulerAngles;

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
            //スマホの向きにカメラを傾ける
            gameObject.transform.rotation = Quaternion.Euler(gyrosan);
        }

        //camera.transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.right) * Input.gyro.attitude * Quaternion.AngleAxis(180.0f, Vector3.forward);
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
}

