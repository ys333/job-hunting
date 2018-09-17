using UnityEngine;
using System.Collections;

public class haikai: MonoBehaviour {

	public Transform[] wayPoints;
    Animator animator;
	NavMeshAgent agent = null;
    Vector3 apos,arot;
    float time;
	public int currentRoot;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        apos = transform.position;
        arot = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        agent.Resume();
        if(animator){
            animator.SetBool("is_running", Vector3.Distance(transform.position, apos) > 0.5f || Vector3.Distance(transform.localEulerAngles, arot) > 0.5f);
            if(time >=0.5f){
                time = 0;
                arot = transform.localEulerAngles;
                apos = transform.position;
            }
        }
        Vector3 pos = wayPoints[currentRoot].position;
		if(Vector3.Distance(transform.position, pos) < 0.5f)
		{
            currentRoot = (currentRoot < wayPoints.Length - 1) ? currentRoot + 1 : 0;
		}
		agent.SetDestination(pos);

		//GetComponent<NavMeshAgent>().SetDestination(pos);
	}
}
