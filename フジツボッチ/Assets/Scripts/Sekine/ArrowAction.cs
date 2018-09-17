using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAction : MonoBehaviour
{
	/**********************************
     * クラス変数
     * *******************************/
	static Vector2 before;

	[SerializeField]
	Transform line;

	/***********************************
     * クラス関数
     * **********************************/
	private void Start()
	{
		before = Input.mousePosition;
		line.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		transform.rotation = Quaternion.identity;
	}

	void Update()
	{
		//矢印の回転
		Vector2 tmp;
		Vector2 now = Input.mousePosition;

		tmp = before - now;

		line.localScale = new Vector3(1.0f, tmp.magnitude / 500.0f, 1.0f);

		float rot = Mathf.Atan2(tmp.y, tmp.x);

		transform.rotation = Quaternion.Euler(0.0f, 0.0f, rot * Mathf.Rad2Deg - 90.0f);
	}
	//---------------------------------------------------

}
