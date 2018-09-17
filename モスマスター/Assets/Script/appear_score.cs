using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appear_score : MonoBehaviour {

    [SerializeField]
    SpriteRenderer[] m_number;
    [SerializeField]
    GameObject m_plus;
    [SerializeField]
    Sprite[] m_number_sprite;

    [SerializeField]
    Vector2 m_size;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScore(int _score)
    {
        int temp_score = _score;
        int count = 0;

        // 桁数
        while (temp_score > 0)
        {
            temp_score = temp_score / 10;
            count += 1;
        }

        temp_score = _score;
        // 位置決め
        for(int i = 0; i < count; i++)
        {
            float x = ((count > 1 ? (count / 2.0f * m_size.x) : 0) - m_size.x * i )/ 100;
            m_number[i].transform.localPosition = new Vector3(x, m_number[i].transform.localPosition.y);
            m_number[i].sprite = m_number_sprite[temp_score % 10];
            temp_score = temp_score / 10;
        }

        float plusx = ((count > 1 ? (count / 2.0f * m_size.x) : 0) - m_size.x * count) / 100;

        m_plus.transform.localPosition = new Vector3(plusx, m_plus.transform.localPosition.y);
    }
}
