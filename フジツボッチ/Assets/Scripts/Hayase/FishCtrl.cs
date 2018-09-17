using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 魚を制御するクラス
/// </summary>
public class FishCtrl : EnemyBase {

    // 管理用座標
    Vector2 pos;

    // 魚の移動方向
    Vector3 direction = Vector3.left;

    // 移動速度初期値
    [SerializeField, Tooltip("敵の初期移動速度")]
    float moveInitializeSpeed = 0.5f;

    [SerializeField, Tooltip("敵のスケール")]
    private float enemyScale = 0.8f;

    // アニメーション速度
    [SerializeField]
    float animationSpeed = 1.0f;

    // 管理用アニメータ
    Animator anim;

	// Use this for initialization
	void Start () { 
        anim = GetComponent<Animator>();
        anim.speed = animationSpeed;

        InitialSettings(enemyScale, moveInitializeSpeed, transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        //デバック用？
        // サイズ変更, アニメーション速度変更
        transform.localScale = new Vector3(enemyScale, enemyScale);
        anim.speed = animationSpeed;

        EnemyMove();

        // 削除
        if (transform.position.x < -30) Destroy(gameObject);
	}

    public override void EnemyMove()
    {
        // 移動処理
        transform.position = pos;

        // 編集
        enemyPositionX -= enemySpeed * Time.deltaTime;
        pos = new Vector2(enemyPositionX, enemyPositionY);
    }

    /// <summary>
    /// 初期設定
    /// </summary>
    /// <param name="scale">初期サイズ</param>
    /// <param name="speed">初期速度</param>
    /// <param name="x">初期X座標</param>
    /// <param name="y">初期Y座標</param>
    private void InitialSettings(float scale, float speed, float x, float y)
    {
        // 初期値
        enemyPositionX = x;
        enemyPositionY = y;

        // 速度設定
        enemySpeed = speed;

        // サイズ
        enemyScale = scale;
    }
}
