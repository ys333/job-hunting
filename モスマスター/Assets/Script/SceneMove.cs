﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneMove : MonoBehaviour {

    private Button button;
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonPush);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonPush()
    {
        SceneManager.LoadScene("Title");
    }
}
