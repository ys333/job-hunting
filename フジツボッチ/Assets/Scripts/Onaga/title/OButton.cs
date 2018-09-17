using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OButton : MonoBehaviour
{
    public GameObject bgmPlayer;
    private AudioSource touchSE;
    public OFade fade;
    private float SceneChengePoint = 1.0f;
    private float fadeWiteTime = 0.0f;
    private bool sceneFlg;
    public float fadeSpeed;

    void Start()
    {
        touchSE = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!sceneFlg)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchSE.PlayOneShot(touchSE.clip);
                bgmPlayer.SetActive(false);
                fadeSpeed = fade.fadeSpeed;
                sceneFlg = true;
            }
        }
        if (sceneFlg)
        {
            if (!touchSE.isPlaying)
            {
                OnClick();
                //fadeWiteTime += fadeSpeed;
                //if (fadeWiteTime > SceneChengePoint)
                //{
                   
                //}
            }

        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
