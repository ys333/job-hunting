using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TutorialPlayerData
{
    public int score = 0;
    public int hitCount = 0;
    public TitleController tc = null;
}

public class Manager : MonoBehaviour {
    [SerializeField]
    private Text[] scoreText;

    public TutorialPlayerData tutrialPlayer1 = new TutorialPlayerData { };
    public TutorialPlayerData tutrialPlayer2 = new TutorialPlayerData { };

    // Use this for initialization
    void Start()
    {
        //DontDestroyOnLoad(this);
        scoreText[0].text = tutrialPlayer1.score.ToString() + "Pt";
        scoreText[1].text = tutrialPlayer2.score.ToString() + "Pt";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScorePrint(TutorialPlayerData tpd, int pNum)
    {
        scoreText[pNum - 1].text = tpd.score.ToString() + "Pt";
    }

    public static void Liner(Transform t)
    {
        t.DOMoveX(t.position.x - (t.right.x * 10), 3.5f).SetLoops(-1, LoopType.Yoyo);
    }

    public static void Stop()
    {
        return;
    }
}
