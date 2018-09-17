using UnityEngine;
using System.Collections;
/// <summary>
/// 壁を回避して追ってくるスクリプトです。
/// targetに追う対象を登録して使うです。
/// NavMeshAgentと床の焼き付け的なのを登録しないと意味がないです。
/// ｋｗｓｋは↓のURLにて
/// 参考URL　http://qiita.com/AuraOtsuka/items/f6738963644faae25919
/// </summary>
public class MoveToTarget : MonoBehaviour {
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    Vector3 apos, arot;
    float time;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        apos = transform.position;
        arot = transform.localEulerAngles;
    }

    void Update()
   {
        time += Time.deltaTime;
        agent.SetDestination(target.position);
        if (animator)
        {
            animator.SetBool("is_running", Vector3.Distance(transform.position, apos) > 0.5f || Vector3.Distance(transform.localEulerAngles, arot) > 0.5f);
            if (time >= 0.5f)
            {
                time = 0;
                arot = transform.localEulerAngles;
                apos = transform.position;
            }
        }
    }
}