using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleState : MonoBehaviour
{

    private bool fadeFlg;
    private float red, green, blue, alfa;
    private float fadeSeed = 2.0f / 255.0f;
    private float alfaMin = 0.0f;
    private float alfaMax = 1.0f;
    private int status = 0;
    //public float fadeSpeed = 0.f;

    // Use this for initialization
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
        Fade();
    }
    public void Fade()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);

        switch (status)
        {
            case 0:
                alfa += fadeSeed;
                if (alfa >= alfaMax) status = 1;
                break;
            case 1:
                alfa -= fadeSeed;
                if (alfa <= alfaMin) status = 0;
                break;

        }
    }
}
