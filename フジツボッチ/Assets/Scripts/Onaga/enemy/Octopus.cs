using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : EnemyBase {

    public GameObject mainCamera;
    private Vector3 cameraPosition;
    private float moveSpeed = 0.01f;
    // Use this for initialization
    void Start()
    {
        cameraPosition = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition.x += moveSpeed;
        mainCamera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z);
    }
}
