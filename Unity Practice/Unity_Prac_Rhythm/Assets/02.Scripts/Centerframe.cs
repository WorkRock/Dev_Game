using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centerframe : MonoBehaviour
{
    AudioSource myAudio;
    bool musicStart = false;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart)
        {
            if (collision.CompareTag("Note"))
            {
                myAudio.Play();
                musicStart = true;
            }
        }
    }
}
