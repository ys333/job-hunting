using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class SpeadFluctuation : MonoBehaviour
{
    //範囲内にプレイヤーが入った場合速度を低下させるスクリプト
    public float mainusspead = 5;//低下する速度の割合
    //半減させたい場合5と入力する

    public RigidbodyFirstPersonController moveset;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("ｵｫﾝ!");
            moveset.downspead = mainusspead;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("ｯｵﾌ");
            moveset.downspead = 0;
        }
    }
}