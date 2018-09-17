//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

///// <summary>
///// リザルト結果を表示するスクリプト
///// Result.csより情報を受け取っている
///// </summary>
//public class ResultView : MonoBehaviour{
    
    
//    [SerializeField]
//    private ResultEvent hitPositionText;                            //命中箇所を表示させるText
//    [SerializeField]
//    private ResultEvent[] playerHitTimeText = new ResultEvent[2];   //YourHitTimeと表示させるtextとプレイヤーの着弾までの時間をあらわすtext
//    [SerializeField]
//    private ResultEvent[] enemyHitTimeText = new ResultEvent[2];    //EnemyHitTimeと表示させるtextと敵の着弾までの時間を表示させるText
//    [SerializeField]
//    private ResultEvent victoryText;                                //勝敗を表示させるText
//    [SerializeField]
//    private ResultEvent[] lifeText = new ResultEvent[2];            //両者のライフ数のtext
//    [SerializeField]
//    private ResultEvent fadeImage;                                  //resultの上にフェードインで表示する看板の画像

//    private PhotonView photonView;
//    private PhaseCheck phaseCheck;
//    private bool[] resultCheck = new bool[2];

//    //***********************************************************************************************************************************

//    void Start()
//    {
//        photonView = GetComponent<PhotonView>();
//        phaseCheck = GetComponent<PhaseCheck>();
//    }
//    void Update()
//    {
//        if (resultCheck[0] && resultCheck[1])
//        {
//            for (int i = 0; i < resultCheck.Length; i++)
//            {
//                resultCheck[i] = false;
//            }
//            photonView.RPC("ViewClose", PhotonTargets.AllViaServer);
//        }
//    }

//    public void PassViewOpen(Result.VictoryPlayer Victory, Result.HitPosition HitPos = Result.HitPosition.Null, float HitTime = 0.0f, int AfterLife = 0)
//    {
//        Debug.Log("passviewopen");
//        photonView.RPC("ViewOpen", PhotonTargets.AllViaServer, Victory, HitPos, HitTime, AfterLife);
//    }
//    /// <summary>
//    /// リザルトを開く
//    /// </summary>
//    /// <param name="HitPos">命中箇所</param>
//    /// <param name="HitTime">命中までの時間</param>
//    /// <param name="Victory">勝者</param>
//    /// <param name="AfterLife">変動した後のライフ</param>
//    [PunRPC]
//    public void ViewOpen(Result.VictoryPlayer Victory, Result.HitPosition HitPos = Result.HitPosition.Null, float HitTime = 0.0f, int AfterLife = 0)
//    {
//        Debug.Log("viewopen");
//        switch (HitPos)
//        {
//            case Result.HitPosition.Null:

//                hitPositionText.SetText("Miss...",-1,1.5f);
//                break;
//            case Result.HitPosition.Legs:
//                hitPositionText.SetText("Good!", -1, 1.5f);
//                break;
//            case Result.HitPosition.Arms_Body:
//                hitPositionText.SetText("Great!", -1, 1.5f);
//                break;
//            case Result.HitPosition.Head:
//                hitPositionText.SetText("Exciting!", -1, 1.5f);
//                break;
//        }
//        if (HitPos != Result.HitPosition.Null)
//        {
//            playerHitTimeText[0].SetText("YourHitTime is ... ",-1,2.5f);
//            playerHitTimeText[1].SetText(HitTime.ToString() + "s!", -1f,3);
//        }
//        else for(int i=0;i<2;i++) playerHitTimeText[i].SetText(" ", 0,2.5f);
//        if (HitPos != Result.HitPosition.Null)
//        {
//            enemyHitTimeText[0].SetText("EnemyHitTime is ...", -1, 4);
//            enemyHitTimeText[1].SetText(HitTime.ToString() + "s!", -1f, 4.5f);
//        }
//        else for (int i = 0; i < 2; i++) enemyHitTimeText[i].SetText(" ", 0, 4f);
//        switch (Victory)
//        {
//            case Result.VictoryPlayer.None:
//                victoryText.SetText("Draw",2,6f);
//                break;
//            case Result.VictoryPlayer.Player1:
//                victoryText.SetText("Victory!!!",2, 6f);
//                lifeText[0].SetText(null, -1f, 8);
//                lifeText[1].SetText(AfterLife.ToString(),-1f,8);
//                break;
//            default:
//                victoryText.SetText("Lose...",2, 6f);
//                lifeText[0].SetText(AfterLife.ToString(), -1f, 8);
//                lifeText[1].SetText(null, -0.5f, 8);
//                break;
//        }
//    }

//    public void PassResultCheck(int playerCode)
//    {
//        photonView.RPC("ResultCheck", PhotonTargets.AllViaServer, playerCode);
//    }
//    /// <summary>
//    /// リザルトを送るためのチェック
//    /// </summary>
//    /// <param name="playerCode">プレイヤーのID</param>
//    [PunRPC]
//    public void ResultCheck(int playerCode)
//    {
//        if (phaseCheck.NowPhaseGet == PhaseCheck.Phase.ResultPhase)
//        {
//            if (!resultCheck[playerCode])
//            {
//                resultCheck[playerCode] = true;
//                Debug.Log("Player" + (playerCode + 1) + ":" + resultCheck[playerCode]);
//            }
//        }
//    }

//    /// <summary>
//    /// リザルトを閉じる
//    /// </summary>
//    [PunRPC]
//    public void ViewClose()
//    {
//        fadeImage.CloseEvent();
//        hitPositionText.Invoke("TextDelete", 3);
//        for (int i = 0; i < 2; i++)
//        {
//            playerHitTimeText[i].Invoke("TextDelete", 3);
//            enemyHitTimeText[i].Invoke("TextDelete", 3);
//        }

//        if (phaseCheck.NowPhaseGet == PhaseCheck.Phase.ResultPhase)
//        {
//            phaseCheck.PhaseProgress();
//        }

//        victoryText.Invoke("TextDelete", 3);

       
//    }
//}
