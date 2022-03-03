using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;

public class NoteManager : MonoBehaviourPunCallbacks
{
    public int bpm = 0;
    float currentTime = 0;
    PhotonView PV;

    public List<GameObject> notes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
            PV.RPC("CreateNote", RpcTarget.All);
    }

    [PunRPC]
    void CreateNote()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 60d / SoundManager.instance.bpm)
            {
                int randomIndex = Random.Range(0, 5);
                
                PV.RPC("InstantiateNote", RpcTarget.All, randomIndex);
                //notes.Add(n);
                currentTime -= 60f / SoundManager.instance.bpm;
            }
        }
    }

    [PunRPC]
    void InstantiateNote(int randomIndex)
    {
        GameObject tNote = null;

        switch (randomIndex)
        {
            case 0:
                tNote = Resources.Load<GameObject>("Line1Note");
                break;
            case 1:
                tNote = Resources.Load<GameObject>("Line2Note");
                break;
            case 2:
                tNote = Resources.Load<GameObject>("Line3Note");
                break;
            case 3:
                tNote = Resources.Load<GameObject>("Line4Note");
                break;
            case 4:
                tNote = Resources.Load<GameObject>("Line5Note");
                break;
        }

        GameObject n = Instantiate(tNote, tNote.transform.position, tNote.transform.rotation);
    }

}
