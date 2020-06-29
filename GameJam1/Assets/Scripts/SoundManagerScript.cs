using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip transitionSound, possessSound;
    static AudioSource audioSrc;


    void Start()
    {
        //transitionSound = Resources.Load<AudioClip>("");
        //possessSound = Resources.Load<AudioClip>("");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        //switch (clip)
        {
           // case "transitionSound":
               // audioSrc.PlayOneShot();
               // break;
           // case "possessSound":
               // audioSrc.PlayOneShot();
               // break;
        }
    }
 }

