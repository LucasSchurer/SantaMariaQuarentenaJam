using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : CreatureAI
{
    protected override void SetMovementInfo()
    {
        movementInfo = new MovementInfo(7f, 15f);
    }

    void Start()
    {
        SetMovementInfo();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
            movementInfo.velocity.y = 0f;

        movementInfo.velocity.y -= movementInfo.gravity * Time.deltaTime;

        controller.move(movementInfo.velocity * Time.deltaTime);

        movementInfo.velocity = controller.velocity;
    }
}
