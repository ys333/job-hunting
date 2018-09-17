using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunContoller : MonoBehaviour 
{
    /************************************************
     * クラス変数
     ***********************************************/
    [SerializeField]
    private PhotonView myPhotonView = null;
    [SerializeField]
    private Transform bulletSpawn;
    [SerializeField]
    private float bulletSpeed = 4000;
    [SerializeField]
    private float destroyTime = 2.0f;

    private bool isShot = true;
    private bool isReload = true;
    Standby standby;
    /************************************************
     * クラス関数
     ***********************************************/

    void Update()
    {
        //持ち主でないのなら制御させない
        if (!myPhotonView.isMine)
        {
            return;
        }

        //if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown))
        //{
        //    isReload = true;
        //    standby.ReadyCheck(0, true);
        //}

        if (isShot && isReload)
        {
            //if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            //{
            //    isShot = false;
            //    isReload = false;
            //    //Shoot(PhotonNetwork.player.ID);
            //    myPhotonView.RPC("Shoot", PhotonTargets.AllViaServer);
                
            //}
        }
        
    }
    //----------------------------------------------

    //[PunRPC]
    //public void Shoot()
    //{
    //    Debug.Log("shoot!");
    //    ////弾を発射       
    //    //var obj = GameObject.Instantiate(Resources.Load("Bullet"), bulletSpawn.position, transform.rotation) as GameObject;        
    //    //obj.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    //    ////Bulletに持ち主の判別をさせる
    //    //var bullet = obj.GetComponent<Bullet>();
    //    ////bullet.Initialize(PlayerID == PhotonNetwork.player.ID);
        
    //    //Debug.Log(isShot);
    //    ////発射されてから一定時間経過したら破棄する
    //    //Destroy(obj.gameObject, destroyTime);

    //    //isShot = true;
    //}

    
}
