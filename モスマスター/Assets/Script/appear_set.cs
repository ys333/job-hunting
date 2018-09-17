using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appear_set : MonoBehaviour {

    public delegate void CallFunc();

    [SerializeField]
    Sprite[] m_appear_hum;
    [SerializeField]
    GameObject m_appear_scale_obj;
    [SerializeField]
    SpriteRenderer m_appear_hum_obj;
    [SerializeField]
    GameObject m_appear_score_move_obj;
    [SerializeField]
    appear_score m_apper_score = null;
    [SerializeField]
    float m_time = 0;
    [SerializeField]
    float m_alpha_time = 0;

    SpriteRenderer[] m_childs = null;

    // Use this for initialization
    void Start () {
        m_childs = GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 表示するハンバーガーのタイプ
    public void SetAppearHumberger(HT _type, Vector2 _pos,CallFunc _first, CallFunc _func)
    {
        int number = (int)_type;
        int score = GameNumRetention.Instance.GetHumbergerScore(_type);
        transform.position = _pos;
        m_appear_hum_obj.sprite = m_appear_hum[(int)_type];
        m_apper_score.SetScore(score);

        StartCoroutine(AppearScore(_first,_func));
    }

    // 演出
    IEnumerator AppearScore(CallFunc _first, CallFunc _func)
    {
        float time = 0;
        float scale = 0;
        float alpha = 1;

        _first();

        while(scale < 1)
        {
            time += Time.deltaTime;
            if(time > m_time) { time = m_time; }

            scale = time / m_time;

            transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

        time = m_alpha_time;

        while(alpha > 0)
        {
            time -= Time.deltaTime;
            if(time < 0) { time = 0; }

            alpha = time / m_alpha_time;

            foreach(SpriteRenderer sr in m_childs)
            {
                sr.color = new Color(1, 1, 1,  alpha);
            }
            yield return null;
        }

        transform.localScale = new Vector3(0, 0, 0);
        foreach(SpriteRenderer sr in m_childs)
        {
            sr.color = new Color(1, 1, 1, 1);
        }

        _func();

        yield return null;
    }
}
