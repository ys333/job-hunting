using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urchin : EnemyBase
{
    private float activeTimer;
    private float distance;
    private int status;


    AudioSource ActiveSE;
    Animator urchinAnimation;
    public CircleCollider2D circleCollider;
	GameObject mainCamera;

    //ウニのサイズ・座標
    //private Vector2 ActiveColliderSize = new Vector2(7.8f, 7.0f);

    //private Vector2 DefalutColliderSize = new Vector2(5.3f, 5.3f);

    private float ActiveColliderSize = 3.5f;

    private float DefalutColliderSize = 1.5f;
    private Vector2 uchinPosition;
	private Vector2 cameraPosition;

    void Start()
    {
        ActiveSE = GetComponent<AudioSource>();
        mainCamera = GameObject.Find("Main Camera");
        urchinAnimation = GetComponent<Animator>();
        activeTimer = 0.0f;
        status = 0;
        distance = 0.0f;
        uchinPosition = transform.position;
        //カメラオブジェクト取得
    }

    void Update()
    {
        cameraPosition = mainCamera.transform.position;
        if(uchinPosition.x - cameraPosition.x < -10.0f)
        {
            Destroy(gameObject);
        }
        switch (status)
        {
            case 0:
                activeTimer += Time.deltaTime;
                if (activeTimer >= 2.0f)
                {
                    //this.tag = "Enemy";
                    ActiveSE.PlayOneShot(ActiveSE.clip);
                    urchinAnimation.SetBool("ActiveFlg", true);
                    status = 1;
                    circleCollider.radius = ActiveColliderSize;
                }
                break;
            case 1:
                activeTimer -= Time.deltaTime;
                if (activeTimer <= 0.0f)
                {
                    //ウニのタグ変更
                    //this.tag = "FrendUrchin";
                    urchinAnimation.SetBool("ActiveFlg", false);
                    status = 0;
                    circleCollider.radius = DefalutColliderSize;
                }
                break;

        }
    }
}
