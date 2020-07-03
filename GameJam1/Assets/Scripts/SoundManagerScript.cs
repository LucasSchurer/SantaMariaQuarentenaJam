using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip squeekSound, infectionSound;
    static AudioSource audioSrc;

    void Start()
    {
        squeekSound = Resources.Load<AudioClip>("squeek");
        infectionSound = Resources.Load<AudioClip>("transition");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
           case "squeek":
           {
               audioSrc.volume = 0.1f;
               audioSrc.PlayOneShot(squeekSound);
               
               break;
           }

           case "transition":
           {
               audioSrc.volume = 1f;
               audioSrc.PlayOneShot(infectionSound);
               break;
           }
        }
    }
 }

