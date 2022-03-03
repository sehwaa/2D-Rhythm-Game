using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputField;

    [SerializeField] public static byte maxPlayerPerRoom = 2;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Success Join Lobby");
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void Connect()
    {
        PhotonNetwork.NickName = inputField.text;
        Debug.Log("Try connect....");
        PhotonNetwork.JoinLobby();
    }
}
