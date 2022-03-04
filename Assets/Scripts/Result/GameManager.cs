using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI playerNickName;
    public TextMeshProUGUI enemyNickName;
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI enemyScore;
    public TextMeshProUGUI playerVictory;
    public TextMeshProUGUI enemyVictory;

    // Start is called before the first frame update
    void Start()
    {
        playerNickName.text = PhotonNetwork.LocalPlayer.NickName;
        enemyNickName.text = PhotonNetwork.PlayerListOthers[0].NickName;
        playerScore.text = ScoreManager.instance.total.ToString();
        enemyScore.text = ScoreManager.instance.enemyTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(playerScore.text) > int.Parse(enemyScore.text))
        {
            playerVictory.text = "Victory";
        }
        else if (int.Parse(playerScore.text) < int.Parse(enemyScore.text))
        {
            enemyVictory.text = "Victory";
        }
        else if (int.Parse(playerScore.text) == int.Parse(enemyScore.text))
        {
            enemyVictory.text = "Draw";
            playerVictory.text = "Draw";
        }
    }

    public void back()
    {
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene("Lobby");
    }
}
