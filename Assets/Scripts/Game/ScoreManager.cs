using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ScoreManager : MonoBehaviourPunCallbacks
{
    public TextMeshPro score;
    public TextMeshPro combo;

    public TextMeshPro enemyNickname;
    public TextMeshPro enemyScore;
    public TextMeshPro playerNickname;
    public TextMeshPro playerScore;

    public static ScoreManager instance = null;

    public string sc = "";
    public int cb = 0;
    public int total = 0;
    public int enemyTotal = 0;
    public Note.State nowState;

    PhotonView PV;
    ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        instance = this;
        playerNickname.text = PhotonNetwork.LocalPlayer.NickName;
        playerScore.text = "0";
        enemyScore.text = "0";
        enemyNickname.text = PhotonNetwork.PlayerListOthers[0].NickName;

        hash.Add("Score", total);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = sc.ToString();
        combo.text = cb.ToString();

        SetScore();
    }

    void SetScore()
    {
        playerScore.text = total.ToString();
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        enemyScore.text = enemyTotal.ToString();
        hash["Score"] = total;
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (targetPlayer != PhotonNetwork.LocalPlayer)
        {
            enemyTotal = (int)changedProps["Score"];
        }
    }
}
