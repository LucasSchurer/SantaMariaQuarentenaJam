using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player != null)
            transform.position = new Vector2(player.position.x, transform.position.y);
    }
}
