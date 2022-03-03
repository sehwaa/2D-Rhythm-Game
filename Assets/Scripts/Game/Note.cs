using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    float noteSpeed = 5f;

    public enum State
    {
        Perfect,
        Cool,
        Good,
        Bad,
        Miss
    }

    public State state = State.Miss;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * noteSpeed * Time.deltaTime;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Miss"))
        {
            state = State.Miss;
            for (int i = 0; i < JudgeMent.instance.notes.Count; i++)
            {
                if (JudgeMent.instance.notes[i] == this.gameObject)
                {
                    JudgeMent.instance.notes.RemoveAt(i);
                    break;
                }
            }
            ScoreManager.instance.sc = "Miss";
            ScoreManager.instance.cb = 0;
            Destroy(this.gameObject);
            //print("Miss!");
        }
        else if (other.gameObject.name.Contains("Perfect"))
        {
            state = State.Perfect;
        }
        else if (other.gameObject.name.Contains("Cool"))
        {
            state = State.Cool;
        }
        else if (other.gameObject.name.Contains("Good"))
        {
            state = State.Good;
        }
        else if (other.gameObject.name.Contains("Bad"))
        {
            if (!SoundManager.instance.musicStart)
            {
                SoundManager.instance.MusicPlay();
                SoundManager.instance.musicStart = true;
            }
            state = State.Bad;
        }
    }
}
