using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAI : CreatureAI
{
    protected override void SetMovementInfo()
    {
        movementInfo = new MovementInfo(3f, 15f);
    }

    void Start()
    {
        SetMovementInfo();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementPattern != MovementPattern.None)
        {
            if (controller.isGrounded)
            movementInfo.velocity.y = 0f;

            movementInfo.velocity.y -= movementInfo.gravity * Time.deltaTime;

            SelectPattern();

            if (movementInfo.velocity.x != 0)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
            } 
            else if (movementInfo.velocity.x == 0)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", true); 
            }

            controller.move(movementInfo.velocity * Time.deltaTime);

            movementInfo.velocity = controller.velocity;
        }
    }

    private void SelectPattern()
    {
        switch (movementPattern)
        {
            case MovementPattern.Still: 
            {
                Still();
                break;
            }

            case MovementPattern.Wandering:
            {
                Wandering();
                break;
            }
        }
    }

    private void Still()
    {
        movementInfo.velocity.x = 0f;
    }

    private void Wandering()
    {
        if (currentDestination != null)
        {
            if (ReachedDestination(currentDestination))
            {
                // wait before moving again
                wanderingIdleTimeCount = wanderingIdleTime;
                currentDestination = GenerateNewPoint(wanderingRadius);
            }

            if (wanderingIdleTimeCount > 0f)
            {
                movementInfo.velocity.x = 0f;
                wanderingIdleTimeCount -= Time.deltaTime;
            }

            if (wanderingIdleTimeCount <= 0f)
            {
                MoveTo(currentDestination);
                UpdateFacing(currentDestination.x < transform.position.x ? -1 : 1);
            }    
        }
    }
}
