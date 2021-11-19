using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabScroller : MonoBehaviour
{
    public float noteTempo;

    // Start is called before the first frame update
    void Start()
    {
        noteTempo = noteTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, , noteTempo * Time.deltaTime);
        transform.Translate(Vector3.up * noteTempo * Time.deltaTime);
    }
}
