using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverEnshutsu : MonoBehaviour {
    
    public Sprite newsmayoi;
    public Sprite newshasami;
    public float fadeinma;

	// Use this for initialization
	void Start () {
        Invoke("FadeIn", fadeinma);
	}

    void FadeIn()
    {
        int onishi = PlayerPrefs.GetInt("ONISHI");

        

        if (onishi == 0)
        {
            GetComponent<Image>().sprite = newsmayoi;
        }
        else if (onishi == 1)
        {
            GetComponent<Image>().sprite = newshasami;
        }
    }
    public void titlemove(){
        SceneManager.LoadScene("title");
    }
}
