using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zukan : MonoBehaviour {

    
    public Image[] zukan;
    public Sprite[] hum;
    public Text collection;

    private bool[] flgs = new bool[6];
    private float num;


	// Use this for initialization
	void Start () {
        num = 0;

        Zukan_Flag();
         

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        for(int i = 0;i < zukan.Length; i++)
        {
            if (flgs[i])
            {
                zukan[i].sprite = hum[i];
            }
        }
    }
    //図鑑のフラグ
    private void Zukan_Flag()
    {

        for (int i = 0; i < zukan.Length; i++)
        {
            flgs[i] = PlayerPrefs.GetInt("HUMBURGER_" + i, 0) == 1 ? true : false;

            if (flgs[i])
            {
                num++;
            }
        }
        collection.text = (int)(num / 6 * 100) + " %";
        
    }
    
}

