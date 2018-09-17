using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayerCtrl : MonoBehaviour {

    [SerializeField, Tooltip("再生したいAudio")]
    AudioClip bgm;

    AudioSource ausrc;

	// Use this for initialization
	void Start () {
        ausrc = GetComponent<AudioSource>();

        if (bgm == null)
        {
            Debug.Log("再生したいAudioをInspectorに入れてください。");
            return;
        }
        else
        {
            ausrc.clip = bgm;
            ausrc.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
