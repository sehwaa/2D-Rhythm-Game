using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public bool musicStart = false;

    AudioSource myAudio;
    public AudioClip[] audioClips;
    public string playTitle;
    public int bpm = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myAudio = GetComponent<AudioSource>();
        SetMusicInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicPlay()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            if (audioClips[i].name == playTitle)
            {
                myAudio.clip = audioClips[i];
                myAudio.Play();
                break;
            }
        }
    }

    public void SetMusicInfo()
    {
        playTitle = InputManager.instance.chooseMusicName;
        TextAsset musicsData = Resources.Load("musicInfo") as TextAsset;
        Musics m = JsonUtility.FromJson<Musics>(musicsData.ToString());
        for (int i = 0; i < m.musics.Count; i++)
        {
            if (m.musics[i].MUSICNAME == playTitle)
            {
                bpm = m.musics[i].BPM;
            }
        }
    }
}
