using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBase : MonoBehaviour {

    public int enemyType;
    public int enemyHp;
    public int enemyAttac;
    public float enemySpeed;
    public float enemyPositionX;
    public float enemyPositionY;      

    /// <summary>
    /// 敵移動
    /// </summary>
    public virtual void EnemyMove()
    {
    }
}
