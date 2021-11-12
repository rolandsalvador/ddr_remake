using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;

    public bool startPlaying;

    public NoteScroller noteScroller;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                noteScroller.hasStarted = true;

                audioSource.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Note hit on time.");
    }

    public void NoteMissed()
    {
        Debug.Log("Note was missed.");
    }
}
