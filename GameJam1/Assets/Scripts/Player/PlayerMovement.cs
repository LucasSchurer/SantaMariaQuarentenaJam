using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float gravity;
    public float movementSpeed;
    private Vector2 velocity;
    private float smoothVelocity;
    public float accelerationGrounded = 0.2f;
    public bool isGrounded;
    public bool canMove = true;

    void Update()
    {
        if (controller.isGrounded)
            velocity.y = 0f;

        if (canMove)
        {
            float inputX = Input.GetAxisRaw("Horizontal");

            float targetVelocityX = inputX * movementSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref smoothVelocity, accelerationGrounded);
        } 

        velocity.y -= gravity * Time.deltaTime;

        controller.move(velocity * Time.deltaTime);

        velocity = controller.velocity;

        isGrounded = controller.isGrounded;
    }
}
