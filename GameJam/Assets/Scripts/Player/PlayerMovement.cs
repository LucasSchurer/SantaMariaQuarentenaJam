using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody controller;
    public float movementSpeed = 10f;
    public float gravity = 9f;
    public float jumpVelocity = 4f;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 movement = controller.transform.right * inputX + controller.transform.forward * inputZ;
        movement *= movementSpeed;

        controller.velocity = movement;
    }
}
