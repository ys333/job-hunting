using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class setumei : MonoBehaviour {
    /// <summary>
    /// メールを受信するときのスクリプトです。
    /// 表示はmail.csで行います。
    /// </summary>
    Mail mail;
    public string[] mailname;//送り主
    public string[] mailmasage;//本文
    public bool a = true;

    float n = 0;
	// Use this for initialization
	void Start () {
        mail = GameObject.Find("Mail").GetComponent<Mail>();
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (a)
            {
                a = false;
                stock();
            }
        }
    }
    public void stock()
    {
        for (int i = 0; i < mailname.Length; i++)
        {
            if (mail.hairetu > mail.mailname.Length)
            {
                mail.hairetu = 0;
            }
            mail.mailname[mail.hairetu] = mailname[i];
            mail.mailmasage[mail.hairetu] = mailmasage[i];
            mail.hairetu += 1;
        }
        if (!mail.kidou)
        {
            mail.StartCoroutine("setumeikaisi");
            mail.kidou = true;
        }
        Destroy(gameObject);
    }
}
