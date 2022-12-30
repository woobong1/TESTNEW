using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public Text StatusText;
    public InputField NickNameInput;
    public GameObject Cube;
    public string gameVersion = "1.0";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    void Start()
    {
        PhotonNetwork.GameVersion = this.gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player3", Cube.transform.position, Quaternion.identity);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        this.CreateRoom();
    }
    void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }

    void Update()
    {
        
    }
}
