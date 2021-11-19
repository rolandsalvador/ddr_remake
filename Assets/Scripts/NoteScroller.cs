using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public bool hasStarted;

    public GameObject leftArrow, downArrow, upArrow, rightArrow;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(leftArrow, new Vector3(-2.45f, -13, 0), Quaternion.identity);
        SpawnLeftArrow();
        SpawnDownArrow();
        SpawnUpArrow();
        SpawnRightArrow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLeftArrow()
    {
        Instantiate(leftArrow, new Vector3(-2.45f, -13, 0), Quaternion.identity);
    }

    public void SpawnDownArrow()
    {
        Instantiate(downArrow, new Vector3(-0.81f, -13, 0), Quaternion.identity);
    }

    public void SpawnUpArrow()
    {
        Instantiate(upArrow, new Vector3(0.81f, -13, 0), Quaternion.identity);
    }

    public void SpawnRightArrow()
    {
        Instantiate(rightArrow, new Vector3(2.44f, -13, 0), Quaternion.identity);
    }
}
