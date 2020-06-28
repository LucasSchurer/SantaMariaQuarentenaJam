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
    public Direction facing = Direction.Right;

    void Update()
    {
        if (controller.isGrounded)
            velocity.y = 0f;

        if (canMove)
        {
            float inputX = Input.GetAxisRaw("Horizontal");

            float targetVelocityX = inputX * movementSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref smoothVelocity, accelerationGrounded);

            UpdateFacing(inputX);

        } else
            velocity.x = 0f; 

        velocity.y -= gravity * Time.deltaTime;

        controller.move(velocity * Time.deltaTime);

        velocity = controller.velocity;

        isGrounded = controller.isGrounded;
    }

    private void UpdateFacing(float inputX)
    {
        if (inputX == 1)
        {
            if (facing == Direction.Left)
            {
                facing = Direction.Right;

                controller.transform.localScale = new Vector3(-controller.transform.localScale.x, controller.transform.localScale.y, controller.transform.localScale.z);
            }
        }
        else if (inputX == -1)
        {
            if (facing == Direction.Right) 
            {
                facing = Direction.Left;

                controller.transform.localScale = new Vector3(-controller.transform.localScale.x, controller.transform.localScale.y, controller.transform.localScale.z);
            }
        }
    }
}

public enum Direction {Right, Left};
