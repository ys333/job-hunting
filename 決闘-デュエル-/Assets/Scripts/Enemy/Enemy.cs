using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    /*****************************************
    * クラス変数
    *****************************************/
    [SerializeField]
    private PhotonView ePhotonview = null;
    private Renderer eRender = null;
    private Color eColor;
    [SerializeField]
    Result result;

    /**********************************************
    * プロパティ
    **********************************************/
    public static Enemy Instance
    {       
        get; 
        private set; 
    }

    /**********************************************
    * クラス関数
    **********************************************/
    private void Awake()
    {
        if (Instance != null) return;
        else
        {
            Instance = this;
        }
    }
    
	
	// Update is called once per frame
	void Update () {
        /*if (!ePhotonview.isMine)
        {
            return;
        }*/
	}
    //--------------------------------------------


    //ダメージ処理     
    public void DamageDeli(string s,int i)
    {
        Debug.Log(s);
        //ePhotonview.RPC("ColorChange", PhotonTargets.AllViaServer, s);
        if(s == "Head")
        {
            HeadShot();
        }
        else
        {
            Damage(i);
        }               
    }

    //ダメージを受ける
    void Damage(int damage)
    {
        //victoryJudge.Damage(1, damage);
        ePhotonview.RPC("Dead", PhotonTargets.All);
    }
    //ヘッドショットされたら
    void HeadShot()
    {
        Damage(7);
    }
    [PunRPC]
    //プレイヤーが負けたら
    void Dead()
    {
        Destroy(gameObject);
    }

    //弾が当たった部位を赤く点滅させる
    [PunRPC]
    private void ColorChange(string parts)
    {
        Debug.Log(parts);
        GameObject child = GameObject.FindGameObjectWithTag(parts);
        
        eRender = child.GetComponent<Renderer>();
        eColor = eRender.material.color;        

        eRender.material.color = Color.red;
        StartCoroutine(Pause());  
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.1f);
        eRender.material.color = eColor;       
    }
    //-------------------------------------------
}
