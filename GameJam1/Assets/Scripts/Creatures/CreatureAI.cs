using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureAI : MonoBehaviour
{
    public struct MovementInfo
    {
        public float movementSpeed;
        public float gravity;
        public Vector2 velocity;

        public MovementInfo(float movementSpeed, float gravity)
        {
            this.movementSpeed = movementSpeed;
            this.gravity = gravity;
            velocity = new Vector2();
        }
    }
    protected CharacterController controller;
    public MovementInfo movementInfo;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    protected abstract void SetMovementInfo();
}
