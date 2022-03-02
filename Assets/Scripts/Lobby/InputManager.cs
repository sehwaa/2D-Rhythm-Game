using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;
    public string chooseMusicName = null;
    GameObject[] albumArt;
    List<Vector3> originalTransform = new List<Vector3>();
    List<Vector3> originalScale = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        albumArt = GameObject.FindGameObjectsWithTag("LOBBY_ALBUMART");
        for (int i = 0; i < albumArt.Length; i++)
        {
            Vector3 v = new Vector3(albumArt[i].GetComponent<RectTransform>().anchoredPosition.x, albumArt[i].GetComponent<RectTransform>().anchoredPosition.y, 0);
            Vector3 s = albumArt[i].transform.localScale;
            originalTransform.Add(v);
            originalScale.Add(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            if (touchDeltaPosition.x < 0)
            {
                GameObject[] t = new GameObject[albumArt.Length];
                for (int i = 0; i < albumArt.Length; i++)
                {
                    if (i == 0)
                    {
                        albumArt[i].GetComponent<RectTransform>().anchoredPosition = originalTransform[albumArt.Length-1];
                        albumArt[i].transform.localScale = originalScale[albumArt.Length - 1];
                        t[albumArt.Length - 1] = albumArt[i];
                    } else
                    {
                        albumArt[i].GetComponent<RectTransform>().anchoredPosition = originalTransform[i-1];
                        albumArt[i].transform.localScale = originalScale[i-1];
                        t[i - 1] = albumArt[i];
                    }
                }
                albumArt = t;

            } else if (touchDeltaPosition.x > 0)
            {
                GameObject[] t = new GameObject[albumArt.Length];
                for (int i = 0; i < albumArt.Length; i++)
                {
                    if (i == albumArt.Length-1)
                    {
                        albumArt[i].GetComponent<RectTransform>().anchoredPosition = originalTransform[0];
                        albumArt[i].transform.localScale = originalScale[0];
                        t[0] = albumArt[i];
                    }
                    else
                    {
                        albumArt[i].GetComponent<RectTransform>().anchoredPosition = originalTransform[i + 1];
                        albumArt[i].transform.localScale = originalScale[i + 1];
                        t[i + 1] = albumArt[i];
                    }

                }
                albumArt = t;
            }
        }
    }

    public void loadScene()
    {
        chooseMusicName = albumArt[2].transform.GetChild(1).GetComponent<TextMeshPro>().text;
        SceneManager.LoadScene("Game");   
    }
}
