using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public bool musicStart = false;

    AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicPlay()
    {
        myAudio.Play();
    }
}
