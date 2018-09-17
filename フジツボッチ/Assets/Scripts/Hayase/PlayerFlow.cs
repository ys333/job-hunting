using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが波によって流されるスクリプトのクラスです。
/// </summary>
public class PlayerFlow : MonoBehaviour {

    // プレイヤー移動用
    Vector2 pos;

    // 流す際の力
    [SerializeField]
    float flowForce = 5.0f;

    // 流されるときの最大速度
    [SerializeField]
    float maxSpeed = 0.5f;

    // 制御用
    Rigidbody2D rb;

    // 流されるかどうか
    bool flow = true;

	// Use this for initialization
	void Start () {
        // 代入
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();

        // 初期加速
        addForce(-flowForce);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(0)) isFlow = true;
        //Debug.Log(flow);
        if (flow)
        {
            // 左へ
            pos.x -= Time.deltaTime * flowForce;

            // 流される速度を一定にするための処理
            // マックススピードより遅い速度の値ならば加速する
            if (-maxSpeed <= rb.velocity.x) addForce(-flowForce);
        }

        if (Input.GetMouseButtonDown(1)) rb.velocity = new Vector2(0,0);
    }

    /// <summary>
    /// 加速処理
    /// </summary>
    /// <param name="xForce">X方向に加える力</param>
    private void addForce(float xForce)
    {
        rb.AddForce(new Vector2(xForce, 0));
    }

    /// <summary>
    /// 流されるかどうかを設定します
    /// </summary>
    public bool isFlow
    {
        get { return flow; }
        set { flow = value; }
    }
}
