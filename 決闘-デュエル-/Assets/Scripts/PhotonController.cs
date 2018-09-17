using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class PhotonController : PunBehaviour
{
    public readonly byte InstantiateVrAvatarEventCode = 123;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        // Photonに接続する(引数でゲームのバージョンを指定できる)
        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    public override void OnConnectedToPhoton()
    {
        Debug.Log("Photonに接続！");
    }

    // ロビーに入ると呼ばれる
    public override void OnJoinedLobby()
    {
        Debug.Log("ロビーに入りました。");

        // ルームに入室する
        PhotonNetwork.JoinRandomRoom();
    }

    // ルームの入室に失敗すると呼ばれる
   void OnPhotonRandomJoinFailed()
    {
        Debug.Log("ルームの入室に失敗しました。");

        // ルームがないと入室に失敗するため、その時は自分で作る
        // 引数でルーム名を指定できる
        PhotonNetwork.CreateRoom("myRoomName");
    }
}
