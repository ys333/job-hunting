using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHujitsubo : MonoBehaviour
{
	[SerializeField]
	GameObject player;

	void Start()
	{
		Instantiate(player, transform.position, Quaternion.identity);
	}
}
