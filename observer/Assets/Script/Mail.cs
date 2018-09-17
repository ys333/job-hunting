using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mail : MonoBehaviour
{
    /// <summary>
    /// メール内容を表示するスクリプトです。
    /// 受信はsetumei.csで行います。
    /// </summary>
    GameObject textobj;
    stickset stick;
    Text text;
    Image setumeiimage;
    public GameObject jairoRest;
    public string[] mailname = new string[30];//送り主
    public string[] mailmasage = new string[30];//本文
    public int hairetu = 0;
    int genzaimail= 0;
    public float readtyme = 2f;
    Vector3 Imageposition, jairoRestposition;
    public bool a = true;
    float n = 0;
    public bool kidou = false;
    bool touchbool = false;
    public AudioSource se;
    public float time = 0;
    // Use this for initialization
    void Start()
    {
        stick = GameObject.Find("MobileSingleStickControl").GetComponent<stickset>();
        setumeiimage = GetComponent<Image>();
        text = transform.FindChild("Text").GetComponent<Text>();
    }
    void Update(){
        if (touchbool)
        {
            time += Time.deltaTime;
            if (time >= 4) {
                touchbool = false;
                StartCoroutine("touch");
            }
        }
    }
    // Update is called once per frame
    public IEnumerator setumeikaisi()
    {
        Handheld.Vibrate();//バイブレーションを起こす
        se.Play();
        text.text = "<b>" + mailname[genzaimail].ToString() + "からの新着メッセージです。</b>\n" + mailmasage[genzaimail].ToString();
        /*n = 0;
        while (n <= 1)//開始時の暗転
        {
            n += 0.2f;
            setumeiimage.color = new Color(1, 1, 1, 0 + n);
            yield return null;
        }*/
        iTween.MoveBy(gameObject, iTween.Hash(

            "y", -300,
            "easeType", iTween.EaseType.linear, "isLocal", true

        ));
        iTween.MoveBy(jairoRest, iTween.Hash(

           "y", -300,
           "easeType", iTween.EaseType.linear, "isLocal", true

        ));
        yield return new WaitForSeconds(1.5f);
        genzaimail += 1;
		time = 0;
        touchbool = true;
    }
    public void button()
    {
        stick.ok = false;
        if (kidou && touchbool)
        {
            touchbool = false;
            StartCoroutine("touch");
        }
    }
    IEnumerator touch()
    {
        n = 0;
        /*while (n <= 1)//開始時の暗転
        {
            n += 0.2f;
            setumeiimage.color = new Color(1, 1, 1, 1 - n);
            yield return null;
        }*/
        iTween.MoveBy(gameObject, iTween.Hash(

        "y", 300,
        "easeType", iTween.EaseType.linear, "isLocal", true


        ));
        iTween.MoveBy(jairoRest, iTween.Hash(

           "y", 300,
           "easeType", iTween.EaseType.linear, "isLocal", true


        ));
        yield return new WaitForSeconds(1.5f);
        text.text = "";
        Debug.Log(genzaimail+""+hairetu);
        if (hairetu == genzaimail) {
            kidou = false;
        }
        else
        {
            StartCoroutine("setumeikaisi");
        }
    }
}
