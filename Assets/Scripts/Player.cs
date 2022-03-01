using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                    //NoteManager.instance.GetNoteState();
                }
            }
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    NoteManager.instance.GetNoteState();
        //}
    }
}
