using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    public GameObject ranking;
    public Text[] rankText = new Text[10];

	// Use this for initialization
	void Start () {
        ranking.SetActive(true);
        if (PlayerPrefs.HasKey("RANKING_KEY"))
        {
            RankingDisPlay();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void RankingDisPlay()
    {
        string rankingString = PlayerPrefs.GetString("RANKING_KEY");
        string[] score = rankingString.Split(","[0]);
        for(int i= 0; i < rankText.Length ; i++)
        {
            rankText[i].text = score[i];
        }
    }
}
