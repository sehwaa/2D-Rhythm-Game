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
                        print(n.GetComponent<Note>().state);
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
