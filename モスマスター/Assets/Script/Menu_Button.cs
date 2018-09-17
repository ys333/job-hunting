using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Button : MonoBehaviour {

    
    public Button playButton;
    public Button zukanButton;
    public Button zukanBack;
    public GameObject zukanPanel;
    // Use this for initialization
    void Start () {
        playButton.onClick.AddListener(Play);
        zukanButton.onClick.AddListener(ZukanDisPlay);
        
        zukanBack.onClick.AddListener(ZukanBack);
        
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    //ゲームプレイ
    public void Play()
    {
        
        SceneManager.LoadScene("Game_Scene");
    }
    //図鑑表示
    public void ZukanDisPlay()
    {
        zukanPanel.SetActive(true);
    }
    //メッセージ表示
    public void MessageDisPlay()
    {
        
    }
    //図鑑閉じる
    public void ZukanBack()
    {
        zukanPanel.SetActive(false);
    }
    //メッセージ図鑑
    public void MessageBack()
    {

    }
}
