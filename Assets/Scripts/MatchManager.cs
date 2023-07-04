using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class MatchManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public static MatchManager instance;
    private void Awake()
    {
        instance = this;
    }

    public enum EvenCodes : byte
    {
        PlayerData,
        PlayerMove,
        TimeRemain
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code < 200)
        {
            EvenCodes events = (EvenCodes)photonEvent.Code;
            object[] data = (object[])photonEvent.CustomData;

            Debug.Log("Event: " + events);

            switch (events)
            {
                case EvenCodes.PlayerMove:
                    PlayerMoveReceive(data);
                    break;

                case EvenCodes.TimeRemain:
                    //TimeReceive(data);
                    break;
            }
        }
    }

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void PlayerData(string username, int win, int lose, int draw)
    {
        // creating data;
        object[] package = new object[4];

        package[0] = username; //player name
        package[1] = PhotonNetwork.LocalPlayer.ActorNumber;// index
        package[2] = 0; //kills
        package[3] = 0; //deaths
        // sending data:
        PhotonNetwork.RaiseEvent(
            (byte)EvenCodes.PlayerData,
            package,
            new RaiseEventOptions { Receivers = ReceiverGroup.Others },
            new SendOptions { Reliability = true }
            );
    }

    public void PlayerMoveSend(Vector2 from, Vector2 to)
    {
        object[] package = new object[2];
        package[0] = from;
        package[1] = to;
        PhotonNetwork.RaiseEvent(
            (byte)EvenCodes.PlayerMove,
            package,
            new RaiseEventOptions { Receivers = ReceiverGroup.Others },
            new SendOptions { Reliability = true }
            );
    }

    public void PlayerMoveReceive(object[] data)
    {
        Debug.Log($"Move from {(Vector2)data[0]} to {(Vector2)data[1]}.");
        GameManager.instance.OnPlayerMove((Vector2)data[0],(Vector2)data[1]);
        GameManager.isYourTurn = true;
    }
}
