﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PhaseCheck : MonoBehaviour {

//    //[HideInInspector]
//    //public enum Phase                               //フェイズのenmu
//    //{
//    //    StandbyPhase,                               //準備
//    //    CointossPhase,                              //コイントス
//    //    BattlePhase,                                //射撃
//    //    ResultPhase,                                //リザルト
//    //    GameSetPhase,                               //ゲームセット
//    //}

//    //[SerializeField]
//    //private Phase roundPhase = Phase.StandbyPhase;  //現在のフェイズ
//    //private RoundCount roundCount;                  //ラウンドを管理する

//    private AudioSource hummerSound;                 //結果表示用
////*****************************************************************************

//    void Start()
//    {
//        roundCount = GetComponent<RoundCount>();    //現在のラウンド数を取得する為
//#if UNITY_EDITOR
//        Debug.Log("デバッグ中（UnityEditor）のみ\n右矢印キーでフェイズを進められます。");
//#endif
//    }

//    void Update()
//    {
        
//#if UNITY_EDITOR

//        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))//デバッグ中（UnityEditor）でのみフェイズを進めるられるように
//        {
//            PhaseProgress();
//        }
//#endif
//    }

////*****************************************************************************

//    /// <summary>
//    /// 現在のフェーズの状況の取得を行う
//    /// </summary>
//    public Phase NowPhaseGet
//    {
//        get { return roundPhase; }
//        set { roundPhase = value; }
//    }

//    /// <summary>
//    /// フェイズの進行を行う
//    /// </summary>
//    public void PhaseProgress()
//    {
//        if (roundPhase == Phase.ResultPhase)
//        {
//            roundPhase = Phase.StandbyPhase;
//            roundCount.NextRound();
//        }
//        else roundPhase++;
//        Debug.Log("<color=blue>" + roundPhase + roundCount.RoundCountChack.ToString() + "</color>");
//    }
//}
