using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float noteTempo;

    public bool hasStarted;

    GameObject noteHolder;

    public GameObject leftArrow, downArrow, upArrow, rightArrow;

    // Start is called before the first frame update
    void Start()
    {
        noteTempo = noteTempo / 60f;
        transform.position += new Vector3(0f, noteTempo * Time.deltaTime, 0f);

        Instantiate(leftArrow, new Vector3(-2.45f, -13, 0), Quaternion.identity);
        noteHolder = GameObject.Find("NoteHolder");

        //leftArrow.transform.parent = noteHolder.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (hasStarted == true)
        //{

        //}
    }
}
