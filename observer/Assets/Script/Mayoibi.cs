using UnityEngine;
using System.Collections;

public class Mayoibi : MonoBehaviour {
    find Find;
    PLstatus at;
    MoveToTarget movetotarget;
    GameObject enemy;
    public bool captureMode;
    NavMeshAgent agent;
	bool AItoggle;
    Animator animator;
    float time,time2;
    Vector3 apos, arot;
    public Transform target;
    public float tuisekizikan = 2.0f;
    public int damage = 5;
    public GameObject player;
    
    
	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        apos = transform.position;
        arot = transform.localEulerAngles;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (animator)
        {
            time2 += Time.deltaTime;
            animator.SetBool("is_running", Vector3.Distance(transform.position, apos) > 0.5f || Vector3.Distance(transform.localEulerAngles, arot) > 0.5f);
            if (time2 >= 0.5f)
            {
                time2 = 0;
                arot = transform.localEulerAngles;
                apos = transform.position;
            }
        }
        

		if (AItoggle == true) {
			MayoibiAI ();//専用AI起動
		}
	}
	void MayoibiAI(){
        transform.LookAt(new Vector3 (target.position.x,transform.position.y,target.position.z));
		//気合のY軸だけ動かさない仕様
		//targetに向かって進む
        transform.position += transform.forward * (agent.speed / 160f);//追いかけるスピード 1フレームごとに一定数近づく仕様上小さい数字でも超速い
    }
    void sikaku_sessyoku_hukkatu()
    {
        //視覚判定・接触判定を復活させる
        captureMode = true;
    }
}
