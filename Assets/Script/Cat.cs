using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    AudioSource sfx;
    void Start()
    {
        sfx = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!sfx.isPlaying)
        {
            sfx.Play();
        }
    }
}
