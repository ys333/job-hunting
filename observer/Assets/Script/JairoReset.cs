using UnityEngine;
using System.Collections;

public class JairoReset : MonoBehaviour {
    /// <summary>
    /// このスクリプトはジャイロセンサーの調節を行うスクリプトです
    /// Uiの任意のボタンにこのスクリプトを割り当て、
    /// ボタンを押すことでスマホの縦の傾きを正面にします。
    /// 下準備としてこのスクリプトのインスペクタ上playerに、
    /// camrerakirikaeのスクリプトが入ったgameobjectを割り当ててください。
    /// </summary>
    jairon Jairon;
    Camerakirikae camerakirikae;
    GameObject main;
    Camera hac;
    stickset stick;
    public GameObject player;//camerakirikaeのスクリプトが入ったgameobjectを割り当てる
    Quaternion gyro, gyro1;
    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;
        camerakirikae = player.GetComponent<Camerakirikae>();
        stick = GameObject.Find("MobileSingleStickControl").GetComponent<stickset>();
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void ButtonPush()
    {
        stick.ok = false;
        if (camerakirikae.Playermode)
        {
            //プレイヤーカメラからの判定取得
            Jairon = camerakirikae.mainCamera.GetComponent<jairon>();
        }
        else
        {
            //監視カメラからの判定取得
            Jairon = camerakirikae.HacCamera.GetComponent<jairon>();
        }
        gyro = Input.gyro.attitude;
        gyro = Quaternion.Euler(90, 0, 0) * new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w);
        Jairon.regyrox = gyro.eulerAngles.x;
        //何！？x軸なら横の動きを検知するではないのか！？（何！？レベルを持たないなら、レベル0ではないのか！？）
        //ジャイロセンサーはx軸で縦の動きを検知する。軸が横に向いていると考えてもらえれば大丈夫です。
    }

}
