using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Title : MonoBehaviour {

    public Image touch;//touch to start
    public Image background;//背景
    public GameObject title;
    public float m_title_y;
    private AudioSource audioSource;
    private float time;
    private float t_time;
    private float fadetime = 2.0f;//touch to startの点滅の時間
    private float startTime = 3.0f;//タイトルシーン最初のフェードインの時間
    private bool isFade; //touch to startの点滅のため
    private bool isTitle;//タイトルシーン最初のフェードインのため

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        isFade = false;
        isTitle = true;  
        time = 0;
        t_time = 0;
        StartCoroutine(FadeTitle());
	}
	
	// Update is called once per frame
	void Update () {        
        if (Input.GetButtonDown("Fire1"))
        {                        
            audioSource.Play();
            StartCoroutine(SE_CHECK());
        }

        //touch to startの点滅
        if (isFade)
        {
            time += Time.deltaTime;
            float a = time / fadetime;
            var color = touch.color;
            color.a = a;
            touch.color = color;
            if (touch.color.a >= 1) isFade = false;
        }
        else
        {
            time -= Time.deltaTime;
            float a = time / fadetime;
            var color = touch.color;
            color.a = a;
            touch.color = color;
            if (touch.color.a <= 0) isFade = true;
        }

        //タイトルシーン最初のフェードイン
        if (isTitle)
        {
            t_time += Time.deltaTime;
            float a = t_time / startTime;
            var color = background.color;
            color.a = a;
            background.color = color;
            if (background.color.a >= 1) isTitle = false;
        }

        
    }

    private IEnumerator FadeTitle()
    {
        yield return new WaitForSeconds(1.0f);
        FadeIn();
        yield return new WaitForSeconds(3.0f);
        isFade = true;       
    }

    //タイトルロゴのフェードイン
    private void FadeIn()
    {
        
        iTween.MoveBy(title, iTween.Hash(

            "y", m_title_y,
            "time",0.5f,
            "easyType", iTween.EaseType.linear

        ));
        
    }

    //SEの再生が終わったらシーン移動
    private IEnumerator SE_CHECK()
    {
        
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!audioSource.isPlaying)
            {
                yield return new WaitForSeconds(1.0f);
                SceneManager.LoadScene("Menu");
                break;
            }
        }                                                  
        
    }

    
}

