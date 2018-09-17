using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour {

    [SerializeField]
    GameObject panelPrefab;

    [SerializeField]
    AudioClip ac;

    AudioSource asrc;

    // Use this for initialization =
    void Start () {
        asrc = GetComponent<AudioSource>();
    }

    // ステージのボタン(Easyのボタン)を押した時
    public void stageBtnClick(string stage)
    {
        var pInstance = Instantiate(panelPrefab);
        pInstance.transform.SetParent(gameObject.transform, false);
        ReadPlayerPref.SetStringKey("PlayingStage", stage);

        PlaySE();
    }

    // SEの再生
    public void PlaySE()
    {
        asrc.PlayOneShot(ac);
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
