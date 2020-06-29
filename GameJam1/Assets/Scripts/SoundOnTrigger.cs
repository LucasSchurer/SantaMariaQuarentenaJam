using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnTrigger : MonoBehaviour
{
    public AudioClip playSound;
    public float volume;
    AudioSource audio;
    public bool alreadyPlay = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlay) 
        {
            audio.PlayOneShot(playSound, volume);
            alreadyPlay = true;
        }
    }

}
