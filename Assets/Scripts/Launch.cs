using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.SceneManagement;

public class Launch : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public static Launch Instance;
    public int totalRoom = 0;
    [SerializeField]
    private TMP_Text log;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        log.text = $"{DateTime.Now.ToString()}: Attempts to connect to Network.";
    }

    public override void OnConnectedToMaster()
    {

        PhotonNetwork.JoinLobby();
        //PhotonNetwork.AutomaticallySyncScene = true;
        log.text = $"{DateTime.Now.ToString()}: Attempts to join to Lobby.";
    }

    public override void OnJoinedLobby()
    {
        log.text = $"{DateTime.Now.ToString()}: Successfully entered the lobby.";
    }


    public void CreateOrJoinRoom()
    {
        if(totalRoom > 0)
        {
            JoinRoom();
        }
        else{
            CreateRoom();
        }
    }
    public void CreateRoom()
    {
        string letters = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string roomName = "";
        for (int i = 0; i < 3; i++)
        {
            int index = UnityEngine.Random.Range(0, letters.Length);
            roomName += letters[index];
        }
        RoomOptions option = new RoomOptions();
        option.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(roomName, option);
        //log.text = $"{DateTime.Now.ToString()}: Create room {roomName} successfully.";
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnCreatedRoom()
    {
        log.text = $"{DateTime.Now.ToString()}: Create room {PhotonNetwork.CurrentRoom.Name} successfully.";
    }

    public override void OnJoinedRoom()
    {
        if (!PhotonNetwork.IsMasterClient)
            log.text = $"{DateTime.Now.ToString()}: Join room {PhotonNetwork.CurrentRoom.Name} successfully.";
        if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (newPlayer != PhotonNetwork.LocalPlayer)
            log.text = $"{DateTime.Now.ToString()}: Your opponent has entered the room.";
        if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int count = 0;
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].PlayerCount == 1 && !roomList[i].RemovedFromList)
            {
                count++;
            }
        }
        totalRoom = count;
        Debug.Log(count);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
