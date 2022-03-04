using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public TextMeshPro playerNickName;
    public TextMeshPro enemyNickName;
    public TextMeshPro playerScore;
    public TextMeshPro enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
