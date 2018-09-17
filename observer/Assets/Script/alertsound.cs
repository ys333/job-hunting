using UnityEngine;
using System.Collections;

public class alertsound : MonoBehaviour {
    /// <summary>
    /// 【注意】

    /// </summary>
	public NavMeshAgent[] enemy = new NavMeshAgent[1];
	public AudioClip sound;        	// 物音の格納用。
	public AudioClip sound2;        // 警告音の格納用。
	private AudioSource audioSource;    // AudioSorceコンポーネント格納用
	float time;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player"){
			audioSource.PlayOneShot(sound);//物音をならす
			for(int i = 0;i<enemy.Length;i++){
				enemy [i].SetDestination (transform.position);//対象の敵の移動先を変更する。
			}
		}
	}
}
