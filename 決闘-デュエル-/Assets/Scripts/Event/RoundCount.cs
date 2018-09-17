//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// 現在のラウンド数を管理するスクリプト
///// </summary>
//public class RoundCount : MonoBehaviour {
    

//    [SerializeField]
//    private int roundCount; //現在のラウンド数
//    private PhaseCheck phaseCheck;

//    /////////////////////////////////////////////////////////////////////////

//    void Start()
//    {
//        phaseCheck = GetComponent<PhaseCheck>();

//    }

///////////////////////////////////////////////////////////////////////////

//    /// <summary>
//    /// ラウンド数を取得する
//    /// </summary>
//    public int RoundCountChack
//    {
//        get{ return roundCount; }
//    }

//    public void NextRound()
//    {
//        roundCount++;
//        if (roundCount >= 6)
//        {
//            phaseCheck.NowPhaseGet = PhaseCheck.Phase.GameSetPhase;
//        }
//        Debug.Log("roundCount:"+roundCount);
//    }
    
//}
