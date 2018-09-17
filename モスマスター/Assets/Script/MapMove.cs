using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour {

	// 配列つくった

	public int[,] array;
    string print_array;
    // Use this for initialization
    void Start () {
		
    }

	void Awake(){
		CreateArray ();
	}
    // Update is called once per frame
    void Update()
    {

        
    }

	public void CreateArray(){
		print_array = "";
        // int[19,14]
        array =  new int[19, 14] 
        {
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
            {(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE,(int)HM.NONE },
        };

        //ぶちこんでる 壁ね
        for (int i = 0; i < array.GetLength(0); i++){
			array [i, 0] = -2;
			array [i, array.GetLength(1)-1] = -2;
		}
		for (int j = 0; j < array.GetLength (1); j++) {
			array [array.GetLength(0)-1, j] = -1;
		}

        // 確認のやつDebug.Logでやつ
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {

                print_array += array[i, j].ToString() + ":";

                //				Debug.Log (array [i, j] + ":¥n");
            }
            print_array += "\n";

        }

    }

}

