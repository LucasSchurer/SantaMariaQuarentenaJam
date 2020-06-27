using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private BoxCollider2D coll;
    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public void OpenDoor()
    {
        coll.enabled = false;
    }
}
