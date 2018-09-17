using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{


    /*******************************************************
     * クラス変数
     * ****************************************************/
    private bool isAction = false;
    [SerializeField, Tooltip("プレイヤーのRigidBody2D")]
    private Rigidbody2D myRigidbody;
    private Vector2 direction;
    [SerializeField, Tooltip("プレイヤーのAnimator")]
    private Animator anim;
    private Animator hujiAnim;
    [SerializeField, Tooltip("プレイヤーPlayerFlowのAnimator")]
    private PlayerFlow flow;
    private GameObject gameOverPanel;
    private GameObject loadManager;
    [SerializeField, Tooltip("PlayerControlerのスクリプト")]
    private PlayerController playerControlerScript;
    private CameraMove cameraMove;
    private Transform hujitsuboTransform;
    private Transform playerSpot;
    /******************************************************
     * プロパティ
     * ***************************************************/

    public bool IsAction
    {
        get { return isAction; }
        set { isAction = value; }
    }
    public Rigidbody2D MyRigidbody
    {
        get { return myRigidbody; }
    }
    public Transform HujitsuboTransform
    {
        get { return hujitsuboTransform; }
    }
    public Transform PlayerSpot
    {
        get { return playerSpot; }
    }
    /******************************************************
     * クラス関数
     * ***************************************************/
    void Start()
    {
        loadManager = GameObject.Find("Manager/LoadManager");
        cameraMove = GameObject.Find("Main Camera").GetComponent<CameraMove>();
    }


    void OnCollisionEnter2D(Collision2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Wall":
                //壁に当たった時のSE
                playerControlerScript.SePlay(3);
                anim.SetBool("IsZitabata", true);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //当たったオブジェクトのタグによって処理変更
        switch (collider.gameObject.tag)
        {

            case "Hujitsubo":
            case "HujitsuboReverse":
                Hujitsubo(collider.gameObject.transform,collider.gameObject.tag);
                //ふじつぼに入った時のSE
                playerControlerScript.SePlay(2);
                break;
            case "Goal":
                myRigidbody.velocity = Vector2.zero;
                SceneManager.LoadScene("GameClear");
                break;
            case "Enemy":
                switch (collider.gameObject.name)
                {
                    case "Fish":
                        playerControlerScript.SePlay(5);
                        break;
                    case "urchin":
                        playerControlerScript.SePlay(4);
                        break;
                }
                
                flow.enabled = false;
                anim.SetTrigger("IsGameOver");
                //操作不能にする
                myRigidbody.velocity = Vector2.zero;
                playerControlerScript.enabled = false;
                cameraMove.enabled = false;
                loadManager.GetComponent<StageGeneration>().ShowPanel();
                break;
            default:
                break;
        }
        myRigidbody.simulated = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Hujitsubo"||collider.gameObject.tag == "HujitsuboReverse")
        {
            collider.gameObject.GetComponent<Animator>().SetBool("IsHujitsubo", false);
        }
    }

    /// <summary>
    /// ふじつぼ処理
    /// </summary>
    /// <param name="pos">ふじつぼのTransform</param>
    void Hujitsubo(Transform pos,string tag)
    {
        //他のスクリプトにふじつぼのTransformを渡すために格納
        hujitsuboTransform = pos;
        //プレイヤーのジタバタのアニメーションを変更
        anim.SetBool("IsZitabata", false);
        //入っているふじつぼのアニメーションを変更
        pos.gameObject.GetComponent<Animator>().SetBool("IsHujitsubo", true);
        //ふじつぼに入っている状態のアニメーションに変更
        anim.SetBool("IsPlayer", false);
        //流れを止める
        flow.isFlow = false;
        //飛べるようにする
        isAction = true;

        //プレイヤーをふじつぼのポジションに固定
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.simulated = false;
        transform.rotation = Quaternion.identity;
        playerSpot = pos.Find("PlayerSpot");
        transform.position = playerSpot.position;
        if(tag == "HujitsuboReverse")
        {
            transform.rotation = playerSpot.rotation;
        }
    }

    
    //-------------------------------------


}