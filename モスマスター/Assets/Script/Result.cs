using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    public Canvas canvas;
    public Text Score;
    public Text Time;
    public Text Bonus;
    public Text highScore;
    public Button homeButton;
    public GameObject totalScore;
    public Image likeImage;
    public AudioClip audioClip;
    public Sprite[] likeSprite; //大好きハンバーガーの画像
    public Sprite[] totalSprite; //トータルスコアの画像

    private int t_score;
    private float t_time;
    private int t_hum;
    private float bonus;
    private int newScore;
    private int[] ranking = new int[10];
    private AudioSource totalSE;
    private AudioSource scoreSE;
    private AudioSource timeSE;
    private AudioSource humSE;
    


   

	// Use this for initialization
	void Start () {
        Score.text = "0";
        Time.text = "00 : 00";
        Bonus.text = "+0%";
        highScore.text = " ";

        likeImage.enabled = false;
        homeButton.interactable = false;

        totalSE = GetComponent<AudioSource>();
        scoreSE = Score.transform.gameObject.GetComponent<AudioSource>();
        timeSE = Time.transform.gameObject.GetComponent<AudioSource>();
        humSE = likeImage.transform.gameObject.GetComponent<AudioSource>();

        t_score = GameNumRetention.Instance.GetScore(); //Random.Range(180000, 189999);
        t_time = GameNumRetention.Instance.GetTimeNum();
        t_hum = (int)GameNumRetention.Instance.GetMaximumHumbergerType();

        GameNumRetention.Instance.ResetHumbergerCount();
        GameNumRetention.Instance.ResetScore();
        GameNumRetention.Instance.ResetTimeNum();

        StartCoroutine(LateDisplay());

        if (PlayerPrefs.HasKey("RANKING_KEY"))
        {
            GetRanking();
        }
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    //保存したランキング情報を取得
    private void GetRanking()
    {
        string rankingString = PlayerPrefs.GetString("RANKING_KEY");
        string[] score = rankingString.Split(","[0]);
        ranking = new int[10];
        for(int i = 0; ranking.Length > 0; i++)
        {
            ranking[i] = int.Parse(score[i]);
        }
        highScore.text = ranking[0].ToString();
    }

    private IEnumerator LateDisplay()
    {
        yield return new WaitForSeconds(1.0f);        
        ResultScore();
        yield return new WaitForSeconds(1.15f);
        ResultTime();
        yield return new WaitForSeconds(5.0f);
        LikeHum();
        humSE.Play();
        yield return new WaitForSeconds(1.5f);
        TotalScore();
        HighScore();
        totalSE.Play();
        homeButton.interactable = true;
    }

    private void ResultScore()
    {
        StartCoroutine(d_Score());
        //Score.text = t_score.ToString();
        Debug.Log(t_score);
    }

    private IEnumerator d_Score()
    {
        
        float score_tmp = 0;
        float add = 0;
        //int count = 0;

        add = t_score / 260;
        scoreSE.Play();
        while (score_tmp < t_score)
        {
            /*count++;
            if(count >= 5)
            {
                scoreSE.Play();
                count = 0;
            }*/
            
            score_tmp += add;

            if (score_tmp >= t_score) score_tmp = t_score;
            Score.text = score_tmp.ToString();
            
            yield return null;
            
        }
        scoreSE.clip = audioClip;
        scoreSE.Play();
    }

    private void ResultTime()
    {
        StartCoroutine(d_Time());

        /*string minText, secText;

        int minute = (int)t_time / 60;
        int seconds = (int)t_time % 60;

        if (minute < 10)
            minText = "0" + minute.ToString();
        else
            minText = minute.ToString();

        if (seconds < 10)
            secText = "0" + seconds.ToString();
        else
            secText = seconds.ToString();

        Time.text = minText + " : " + secText;*/
    }

    private IEnumerator d_Time()
    {
        float time_tmp = 0;
        float add = 0;
        //int count = 0;

        add = t_time / 260;
        timeSE.Play();
        while (time_tmp < t_time)
        {
            /*count++;

            if(count >= 5)
            {
                timeSE.Play();
                count = 0;
            }*/
            
            time_tmp += add;

            if (time_tmp >= t_time) time_tmp = t_time;

            string minText, secText;

            int minute = (int)time_tmp / 60;
            int seconds = (int)time_tmp % 60;

            if (minute < 10)
                minText = "0" + minute.ToString();
            else
                minText = minute.ToString();

            if (seconds < 10)
                secText = "0" + seconds.ToString();
            else
                secText = seconds.ToString();

            Time.text = minText + " : " + secText;

            
            yield return null;
        }
        timeSE.clip = audioClip;
        timeSE.Play();
    }

    //大好きハンバーガー
    public void LikeHum()
    {
        likeImage.enabled = true;
        likeImage.sprite = likeSprite[t_hum];

        bonus = 0.0f;
        
        switch ((HT)t_hum)
        {
            
            case HT.TERI:
                bonus = 3;
                break;
            case HT.MOS:
                bonus = 5;
                break;
            case HT.DOUBLE:
                bonus = 4;
                break;
            case HT.CHEESE:
                bonus = 3;
                break;           
            case HT.MOS_C:
                bonus = 7;
                break;
            case HT.HUM:
                bonus = 2;
                break;
            default:
                Debug.Log("BONUS_ERROR");
                break;
        }

        Bonus.text = "+" + bonus.ToString() + "%";
        Debug.Log("hum:" + t_hum);
        PlayerPrefs.SetInt("HUMBURGER_"+ t_hum,1);
    }

    //トータルスコア
    public void TotalScore()
    {
        
        t_score += (int)t_time;
        bonus /= 100;
        t_score = (int)((float)t_score * (1 + bonus));

        newScore = t_score;
        var digit = t_score;
        
        List<int> number = new List<int>();
              
        while(digit != 0)
        {
            t_score = digit % 10;
            digit = digit / 10;
            number.Add(t_score);
        }

        if(number.Count == 0) { number.Add(t_score); }

        totalScore.GetComponent<Image>().sprite = totalSprite[number[0]];

        

        for(int i = 1; i < number.Count; i++)
        {
            //複製
            RectTransform scoreImage = (RectTransform)Instantiate(totalScore).transform;
            scoreImage.SetParent(canvas.transform, false);
            scoreImage.localPosition = new Vector2(
                scoreImage.localPosition.x - scoreImage.sizeDelta.x * i,
                scoreImage.localPosition.y
                );
            scoreImage.GetComponent<Image>().sprite = totalSprite[number[i]];
            
        }

        
    }   
    //過去最高
    private void HighScore()
    {
        int ranking_tmp = 0;
        for (int i = 0; i < ranking.Length; i++)
        {
            if(ranking[i] < newScore)
            {
                ranking_tmp = ranking[i];
                ranking[i] = newScore;
                newScore = ranking_tmp;
            }
        }
        highScore.text = ranking[0].ToString();

        string[] rankingString = new string[10];

        for(int i = 0; i < ranking.Length; i++)
        {
            rankingString[i] = ranking[i].ToString();
        }
        string rankingData = string.Join(",", rankingString);

        PlayerPrefs.SetString("RANKING_KEY", rankingData);
        PlayerPrefs.Save();
    }

   
    
}
