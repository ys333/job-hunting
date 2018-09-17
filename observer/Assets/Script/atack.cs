using UnityEngine;
using System.Collections;

public class atack : MonoBehaviour
{
    Mayoibi mayoibi;
    string scriptname;
    NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        mayoibi = transform.root.gameObject.GetComponent<Mayoibi>();
        agent = mayoibi.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (mayoibi.captureMode)
        {
            //Debug.Log(col.gameObject.tag);
            if (col.gameObject.tag == "Player")
            {
                mayoibi.captureMode = false;
                PlayerPrefs.SetInt("ONISHI", 0);
                //捕まった場合
                //プレイヤーにダメージのスクリプト
                agent.velocity = Vector3.zero;
                agent.Stop();
                transform.root.gameObject.GetComponent<Mayoibi>().enabled = false;
                transform.root.gameObject.GetComponent<haikai>().enabled = false;
                //taget.SendMessage("ATtrue");
                col.gameObject.SendMessage("Damage", mayoibi.damage);   //相手のDamage関数を実行する
                col.gameObject.SendMessage("AtackObj", transform.root.gameObject);   //相手のDamage関数を実行する
            }
        }
    }
}
