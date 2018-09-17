using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

public class PhoneCall : MonoBehaviour {
    public stickset st;

    public AudioSource[] audioSource = new AudioSource[2];    // AudioSorceコンポーネント格納用
    
    public Image[] button = new Image[2];
    public int hantei = 0;
    public float phonetime;
    bool a = true;
    bool b = true;
    public Text timetext;
    int secound;
	float time;
	// Use this for initialization
	void Start () {
        st.enabled = false;

        OnUnPause();
	}
	
	// Update is called once per frame
	void Update () {
        CrossPlatformInputManager.SetAxis("Horizontal", 0);
        CrossPlatformInputManager.SetAxis("Vertical", 0);
        if (Input.GetKeyDown("p"))
        {
                OnPause();            
        }
        if (hantei == 2) {
			time += Time.deltaTime;
			if (time >= 1) {
				secound++;
				time = 0;
			}
			if (secound < 10) {
				timetext.text = "00" + "：" + "0"+secound.ToString ();
			} else {
				timetext.text = "00" + "：" + secound.ToString ();
			}
        }
	}

    public void OnClick(int num)
    {
        Debug.Log("clock");
        if (hantei == 0)
        {


            switch (num)
            {
                case 1:
					
                    hantei = 1;
                    st.enabled = true;
                    OnUnPause();
                    break;
                case 2:
                    button[0].enabled = false;
                    button[1].enabled = false;
                    audioSource[1].Play();
                    st.enabled = true;
                    hantei = 2;
                    StartCoroutine("deetaa");
                    break;
                default:
                    break;
            }
        }

        
    }

    public void OnPause()
    {
        if (a)
        {
            
            StartCoroutine("Loop");
            a = false;
        }
        button[0].enabled = true;
        button[1].enabled = true;
        this.GetComponent<Canvas>().enabled = true;
        st.enabled = false;
    }

    public void OnUnPause()
    {
        Debug.Log("iiyo");
        //audioSource.Stop();
        st.enabled = true;
        button[0].enabled = false;
        button[1].enabled = false;
        this.GetComponent<Canvas>().enabled = false;
        timetext.enabled = false;
        a = true;
        b = true;              
    }

    IEnumerator Loop()
    {
        for (int i = 0; i < 4; i++)
        {
			if (hantei == 0){
				Handheld.Vibrate ();//バイブレーションを起こす
				audioSource[0].Play();
			}
			yield return new WaitForSeconds (2.0f);
        }
        if (hantei == 0) {
            Debug.Log("終了");
            OnUnPause(); }  
    }
    IEnumerator deetaa()
    {
        timetext.enabled = true;
        Debug.Log("メロンパン");
        yield return new WaitForSeconds(18f);
        OnUnPause();
    }
}
