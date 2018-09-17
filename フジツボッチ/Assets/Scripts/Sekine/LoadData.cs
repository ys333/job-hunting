using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{

	void Start()
	{
		ReadPlayerPref.SetStringKey("1-1", "stage1");
        ReadPlayerPref.SetStringKey("1-2", "stage2");
        ReadPlayerPref.SetStringKey("1-3", "stage3");
    }
}