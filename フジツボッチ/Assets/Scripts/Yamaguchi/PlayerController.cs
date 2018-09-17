using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    /***********************************************
     * クラス変数
     * ********************************************/
    private Vector2 playerVec; //飛ばす角度
    private float power; // 飛ばす力
    [SerializeField, Tooltip("飛ばす力の最大値")]
    private float maxPower = 500.0f;
    [SerializeField, Tooltip("飛ばす力の最小値")]
    private float minPower = 200.0f;
    private Vector2 clickPosDown, clickPosUp; //ドラッグしたポジション  
    private float pullDistance; // ドラッグした距離
    private GameObject arrow; // 矢印
    [SerializeField, Tooltip("SEを鳴らすAudio")]
    private AudioSource audio;
    [SerializeField]
    private AudioClip[] clip;
    private Slider meter;
    [SerializeField, Tooltip("PlayerMangerTestのスクリプト")]
    PlayerManager playermanagerScript;
    [SerializeField, Tooltip("プレイヤーPlayerFlowのAnimator")]
    PlayerFlow flow;
    [SerializeField, Tooltip("プレイヤーのAnimator")]
    private Animator anim;
	private CameraMove cameraMove;

    /***********************************************
     * クラス関数
     * ********************************************/
    void Start()
    {
        arrow = transform.Find("Arrow").gameObject;
        meter = GameObject.Find("Canvas/Meter").GetComponent<Slider>();
        audio = GetComponent<AudioSource>();
		cameraMove = GameObject.Find("Main Camera").GetComponent<CameraMove>();
    }

    void Update()
    {
        //ふじつぼに入っている状態でのみ飛ぶ
        if (playermanagerScript.IsAction)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //タッチした場所のポジション
                clickPosDown = Input.mousePosition;
                //矢印表示
                arrow.SetActive(true);
                //引っ張った時のSE
                SePlay(0);
                transform.position = playermanagerScript.HujitsuboTransform.position;
            }

            if (Input.GetMouseButtonUp(0))
            {
				if(!cameraMove.IsStart())
				{
					cameraMove.CameraMoveStart();
				}
                //離した場所のポジション
                clickPosUp = Input.mousePosition;
                //矢印非表示
                arrow.SetActive(false);
                

                if (clickPosDown == clickPosUp)
                {
                    transform.position = playermanagerScript.PlayerSpot.position;
                    flow.isFlow = false;
                    //指を離した場所が同じ場所なら処理抜ける
                    return;
                }

                //飛ばす方向の計算
                playerVec = clickPosDown - clickPosUp;
                playerVec.Normalize();
                //ドラッグした距離の計算
                pullDistance = (clickPosDown - clickPosUp).magnitude;
                //飛ばす力の計算
                power = pullDistance * 3.0f;
                

                if (power >= maxPower)
                {
                    //速度制限
                    power = maxPower;
                }
                else if (power < minPower)
                {
                    transform.position = playermanagerScript.PlayerSpot.position;
                    flow.isFlow = false;
                    //速度が低いと発射しない
                    return;
                }
                //飛ばす処理
                playermanagerScript.MyRigidbody.AddForce(playerVec * power);
                //ふじつぼに入っていない時に飛ばせないようにする
                playermanagerScript.IsAction = false;
                //飛ぶ時のSE
                SePlay(1);
                //飛んでいる時のアニメーション
                anim.SetBool("IsPlayer", true);
                
                //流れを再開
                flow.isFlow = true;
            }
            
        }
        
        meter.value = transform.position.x;
    }

    public void SePlay(int number)
    {
        audio.clip = clip[number];
        audio.Play();
    }

}
