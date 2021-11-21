using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabScroller : MonoBehaviour
{
    string sceneName;

    public float noteTempo;

    public float noteSpeed;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "GameEasy")
        {
            noteSpeed = 1.5f;
        }

        if (sceneName == "GameMedium")
        {
            noteSpeed = 2.5f;
        }

        if (sceneName == "GameHard")
        {
            noteSpeed = 4.5f;
        }

        noteTempo = noteTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * noteTempo * noteSpeed);
    }
}
