using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectDecideBtn : MonoBehaviour {

    AudioSource asrc;
    [SerializeField, Tooltip("流したいSE")]
    AudioClip[] ac;

    void Start()
    {
        asrc = GetComponent<AudioSource>();
    }

    // 遊ばない場合
    public void StageCancel()
    {
        PlaySE(1);
        StartCoroutine(Checking(() =>
        {
            Destroy(gameObject);
        }));
    }

    // ステージで遊ぶ場合
    public void StageOK()
    {
        PlaySE(0);
        StartCoroutine(Checking(() =>
        {
            ButtonManager bm = new ButtonManager();
            bm.ToGameScene();
        }));
    }

    public void PlaySE(int num)
    {
        asrc.clip = ac[num];
        asrc.Play();
    }

    // コルーチン　曲が再生し終わっているか判定
    public delegate void functionType();
    private IEnumerator Checking(functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!asrc.isPlaying)
            {
                callback();
                break;
            }
        }
    }

}
