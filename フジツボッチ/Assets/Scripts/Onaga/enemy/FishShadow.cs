using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShadow : MonoBehaviour {
    public GameObject Camera;
    private Vector2 fishShadowPosition;
    private Vector2 cameraPosition;
    float moveSpeed = 0.05f;

    float repeatInterval = 15.0f;

    void Start () {
        fishShadowPosition = transform.position;
        cameraPosition = Camera.transform.position;
    }

	void Update () {
        cameraPosition = Camera.transform.position;
        FishMove();
        if (fishShadowPosition.x - cameraPosition.x < -20.0f)
        {
            fishShadowPosition.x = cameraPosition.x + repeatInterval;
            transform.position = new Vector2(fishShadowPosition.x, fishShadowPosition.y);
        }

    }
    void FishMove()
    {
        fishShadowPosition.x -= moveSpeed;
        transform.position = new Vector2(fishShadowPosition.x, fishShadowPosition.y);
    }
}
