using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCamera : MonoBehaviour
{

    private Vector3 cameraPosition;
    private float moveSpeed = 0.02f;


    // Use this for initialization
    void Start()
    {
        cameraPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
            cameraPosition.x += moveSpeed;
            transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z);
    }
}