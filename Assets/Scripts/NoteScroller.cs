using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float noteTempo;

    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        noteTempo = noteTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            /*if(Input.anyKeyDown)
            {
                hasStarted = true;
            }*/
        }
        else
        {
            transform.position += new Vector3(0f, noteTempo * Time.deltaTime, 0f);
        }
    }
}
