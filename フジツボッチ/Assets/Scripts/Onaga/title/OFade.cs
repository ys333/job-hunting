using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OFade : MonoBehaviour
{
    public float fadeSpeed;
    private bool fadeFlg;
    private float alfa = 0.0f;
    float red, green, blue;

    //public float fadeSpeed = 0.f;

    void Start()
    {
        fadeSpeed = 1.0f / 255.0f;
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            fadeFlg = true;
        }
        if(fadeFlg)
        {
            FadePanel();
        }
    }
    public void FadePanel()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += fadeSpeed;
    }
}
