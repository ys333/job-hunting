﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// リザルトの際文字を動かしたり表示するスクリプト
/// </summary>
public class ResultEvent : MonoBehaviour {
    
    private Text text;      //自身のtextを取得する
    int defaltFontSize;     //元のフォントサイズを取得する
    float animValue;        //変動させるフォントのサイズ
    float deley;            //どれだけ送らせてから動かすか
    string textString;      //実際に表示する文字列
    bool textpopmode;       //アニメーションを行うか
    [SerializeField]
    private AudioSource se; //アニメーションが動く際の音

    Image img;

    /////////////////////////////////////////////////////////

    void Awake () {
        if (GetComponent<Text>())
        {
            text = GetComponent<Text>();
            if (text) defaltFontSize = text.fontSize;
        }
        else if (GetComponent<Image>())
        {
            img = GetComponent<Image>();

        }
    }
    
    //////////////////////////////////////////////////////////////////
    
    /// <summary>
    /// このGameObject(Text)にどのような動きをとらせるか
    /// </summary>
    /// <param name="str">表示する文字列</param>
    /// <param name="value">変動するフォントサイズ</param>
    /// <param name="startTime">アニメーションを開始させるタイミング</param>
    public void SetText(string str,float value,float startTime)
    {
        textpopmode = value != 0;
        text.fontSize = defaltFontSize+(int)(value*3);
        textString = str ?? "null";
        animValue = value;
        deley = startTime;
        if(textpopmode)StartCoroutine("ViewAnim");
    }
    
    IEnumerator ViewAnim()
    {
        yield return new WaitForSeconds(deley);
        if (se) se.Play();
        if (textString != "null") text.text = textString;
        for (int i = 0; i < 3; i++)
        {
            text.fontSize += (int)animValue;
            yield return null;
        }
    }

    /// <summary>
    /// 表示してあるテキストを消去する
    /// </summary>
    public void TextDelete()
    {
        text.text = "";
    }

    public void SetImage()
    {
        img.color = Color.white;
    }

    public void ImageDelete()
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
    }


    /// <summary>
    /// 上からフェードさせてかぶせる画像用の処理
    /// </summary>
    public void CloseEvent()
    {
        StartCoroutine("ImageFadeIn");
    }

    IEnumerator ImageFadeIn()
    {
        Image image=GetComponent<Image>();
        for(float i = 0; i <= 20; i++)
        {
            image.fillAmount = i / 20;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        for (float i = 20; i >= 0; i--)
        {
            image.fillAmount = i / 20;
            yield return null;
        }
    }
}
