using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeMent : MonoBehaviour
{
    public static JudgeMent instance = null;
    public List<GameObject> notes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10.0f) && hit.transform.gameObject.CompareTag("TOUCHZONE"))
                {
                    if (notes.Count > 0)
                    {
                        GameObject n = notes[0];
                        Note.State state = n.GetComponent<Note>().state;
                        switch (state)
                        {
                            case Note.State.Perfect:
                                ScoreManager.instance.sc = "Perfect";
                                ScoreManager.instance.cb += 1;
                                ScoreManager.instance.total += ScoreManager.instance.cb * 5;
                                break;
                            case Note.State.Cool:
                                ScoreManager.instance.sc = "Cool";
                                ScoreManager.instance.cb += 1;
                                ScoreManager.instance.total += ScoreManager.instance.cb * 4;
                                break;
                            case Note.State.Good:
                                ScoreManager.instance.sc = "Good";
                                ScoreManager.instance.cb += 1;
                                ScoreManager.instance.total += ScoreManager.instance.cb * 3;
                                break;
                            case Note.State.Bad:
                                ScoreManager.instance.sc = "Bad";
                                ScoreManager.instance.cb = 0;
                                break;
                            case Note.State.Miss:
                                ScoreManager.instance.sc = "Miss";
                                ScoreManager.instance.cb = 0;
                                break;

                        }
                        Destroy(n);
                        notes.RemoveAt(0);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        notes.Add(other.gameObject);
    }
}
