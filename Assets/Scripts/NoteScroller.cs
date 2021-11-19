using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NoteScroller : MonoBehaviour
{
    public bool hasStarted;

    public float numNotes;

    public GameObject leftArrow, downArrow, upArrow, rightArrow;

    private float Timer;

    public GameObject[] prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            int prefabNum = Random.Range(0, 3);
            switch (prefabNum)
            {
                case 0:
                    SpawnLeftArrow();
                    break;
                case 1:
                    SpawnDownArrow();
                    break;
                case 2:
                    SpawnUpArrow();
                    break;
                case 3:
                    SpawnRightArrow();
                    break;
                default: break;
            }
            Timer = 1f;
            numNotes++;
        }
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
