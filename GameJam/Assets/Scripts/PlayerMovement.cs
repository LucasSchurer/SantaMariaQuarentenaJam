using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float movementSpeed = 10f;
    private Vector3 velocity;
    public float gravity = 9f;
    public float jumpVelocity = 4f;
    public bool isGrounded;
    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 movement = controller.transform.right * inputX + controller.transform.forward * inputZ;
        movement *= movementSpeed;

        if (controller.isGrounded)
            velocity.y = 0f;

        velocity.y -= gravity * Time.deltaTime;

        movement.y = velocity.y;

        controller.Move(movement * Time.deltaTime);
    }
}
