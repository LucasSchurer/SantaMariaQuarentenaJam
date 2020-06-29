using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnTrigger : MonoBehaviour
{

    public AudioSource TocarSom;

    void OnTriggerEnter(Collider other)
    {
        TocarSom.Play();  
    }

}
