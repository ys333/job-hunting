using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PLstatus : MonoBehaviour {
    public float HP = 100;  //体力
    public bool attacker;
    bool GB;
    public float attack;
    bool sup=true;
    GameObject Maincamera;
    public RawImage damage;
    public float shakep = 1.5f;
    GameOver gameover;
    /*
    public Image damage1;
    public Image damage2;
    */
    public int cupcout = 0;//捕まった回数
    GameObject enemy;
    int dam=13;  //連打回数
    Camerakirikae camerakirikae;
    find Find;
    Image Joystick;
    jairon Jairon;
    Mayoibi mayoibi;
    AudioSource[] bgm;
    bool urakamera = false;
    bool audioplay = false;
    bool sunaplay = false;
    public Camera hellcamera;
    GameObject[] enemyobjs = new GameObject[3];
    Vector3[] enemypositions = new Vector3[3];
    int obj = 0;
    public Image shake;
    // Use this for initialization
    void Start () {
        Joystick = GameObject.Find("MobileJoystick").GetComponent<Image>();//ジョイスティック読み取り　名前が変わると動かなくなってしまう
        camerakirikae = GameObject.Find("RigidBodyFPSController").GetComponent<Camerakirikae>();
        Maincamera = gameObject.transform.FindChild("MainCamera").gameObject;
        Jairon = Maincamera.GetComponent<jairon>();
        bgm = gameObject.GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //damage2.color = new Color(1, 1, 1, 1 - HP / 100);
        if (attacker == true)
        {
            //追記点・カメラの切り替えを不可能にして、強制的にプレイヤーモードに切り替える
            //Jairon.enabled = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToPortraitUpsideDown = false;
            camerakirikae.Playermode = true;

            Handheld.Vibrate();//バイブレーションを起こす

            //追記ここまで
            if (!urakamera)
            {
                urakamera = true;
                hellcamera.enabled = true;
            }
            //プレイヤーに鬼を強制的に向かせ、ﾌﾞﾙｯﾌﾞﾙ震えさせる
            if (enemy != null) {
                Maincamera.transform.LookAt(enemy.transform);
                iTween.ShakePosition(Maincamera, iTween.Hash("x", 0.2f, "y", 0.2f, "time", 0.5f));
            }
            

            //ジャイロセンサーを機能しないようにする
            Jairon.enabled = false;


            HP -= attack/100;//捕まった状態なら体力が減っていく
            //damage1.color = new Color(1, 1, 1, 1 - HP / 100);
            damage.color = new Color(1, 1, 1, 1 - HP / 200);
        }
        if (sup && HP < 100)
        {
            HP += 0.8f;
        }//徐々に回復

        if (HP >= 100)
        {
            HP = 100;
        }


        if (HP <= 0)//体力がなくなった場合
        {
            if (!sunaplay)
            {
                sunaplay = true;
                bgm[2].Play();
            }
            bgm[1].Stop();
            gameObject.GetComponent<GameOver>().enabled = true;
            GB = true;//ゲームオーバー
            attacker = false;
        }

        //スマホを振ることによる抵抗
        //追記点・加速度センサーを検知する。
        Vector3 dir = Input.gyro.rotationRateUnbiased;
        dir.x = Input.acceleration.x;//スマホの加速度のx（横）を検知
        dir.y = Input.acceleration.y;//スマホの加速度のy（縦）を検知
        dir.z = Input.acceleration.y;//スマホの加速度のz（傾き？）を検知
        if (attacker == true && (dir.x >= shakep|| dir.y >= shakep || dir.x <= -shakep || dir.y <= -shakep || dir.z >= shakep || dir.z <= -shakep))
            //ダメージを受けていてかつ｛スマホが横に1.5動く、あるいは縦に1.5動くあるいは1.5傾くのどれか｝
        {
            cupcout++;
        }
        //

        
#if UNITY_EDITOR
        //画面クリックによる抵抗
        if (attacker == true&&Input.GetMouseButtonDown(0))
        {
            cupcout++;
        }
#endif

        if (dam <= cupcout)
        {
            shake.enabled = false;
            dam = dam * 2;
            cupcout = 0;
            Invoke("supON", 3);
            ATfalse();
        }

	}

    public void ATfalse()//解除
    {
        Joystick.enabled = true;
        if (audioplay)
        {
            audioplay = false;
            bgm[1].Stop();
        }
        damage.color = new Color(1, 1, 1, 0);
        hellcamera.enabled = false;
        attacker = false;
        enemy.GetComponent<Mayoibi>().enabled = true;
        enemy.GetComponent<haikai>().enabled = true;
        enemyobjs[obj] = enemy;
        enemypositions[obj] = enemy.transform.position;
        enemy.transform.position = new Vector3(0,0,0);
        if (obj < 3)
        {
            obj++;
        }else {
            obj = 0;
        }

        Jairon.enabled = true;
        mayoibi.Invoke("sikaku_sessyoku_hukkatu", 10);//2秒後視覚と接触の判定が復活する。
        //追記点・カメラの切り替えを再度可能にする
        //Jairon.enabled = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToPortraitUpsideDown = true;

        //追記ここまで

    }

    public void Damage(float damage)//敵に触れる
    {
        Debug.Log("DAMAGE");
        shake.enabled = true;
        if (!audioplay)
        {
            audioplay = true;
            bgm[1].Play();
            bgm[0].Stop();
        }
        
        attack = damage;
        Joystick.enabled = false;
        sup = false;
        attacker = true;
    }
    public void AtackObj(GameObject atackobj)//敵に触れる
    {
        enemy=atackobj;
        Find = enemy.transform.FindChild("find").gameObject.GetComponent<find>();
        mayoibi = enemy.GetComponent<Mayoibi>();
    }

    void OnGUI()//確認用デバッグGUI
    {/*
        GUI.Label(new Rect(20, 20, 100, 50), "HP" + HP);
        GUI.Label(new Rect(20, 40, 100, 50), "" + attacker);

        GUI.Label(new Rect(20, 100, 100, 50), "COUNT" + cupcout);
        GUI.Label(new Rect(20, 120, 100, 50), "dam" + dam);
        if (GB == true) { GUI.Label(new Rect(200, 200, 100, 50), "GAMEOVER"); }
      * */
    }
    

    void supON()//Invokeで3秒後にtrueにするための関数
    {
        sup = true;
    }
}

/*
数値とか適当な場所多いので指示とかください
*/

