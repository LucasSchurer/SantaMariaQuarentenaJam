using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureAI : MonoBehaviour
{
    public MovementPattern movementPattern;
    public Vector2 currentDestination;

    public float wanderingRadius = 5f;
    public float wanderingIdleTime = 2f;
    public float wanderingIdleTimeCount = 2f;

    protected Animator anim;
    protected BoxCollider2D coll;

    public Direction facing = Direction.Right;

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
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();

        if (movementPattern == MovementPattern.Wandering)
        {
            currentDestination = GenerateNewPoint(wanderingRadius);
        }
            
    }

    protected abstract void SetMovementInfo();

    protected Vector2 GenerateNewPoint(float radius)
    {
        float minX = transform.position.x - radius;
        float maxX = transform.position.x + radius;

        float xPoint = Random.Range(minX, maxX);

        return new Vector2(xPoint, 0f);
    }

    protected Vector2 GenerateNewPoint(float radius, float direction)
    {
        return new Vector2();
    }

    protected void MoveTo(Vector2 destination)
    {
        if (destination.x > transform.position.x)
            movementInfo.velocity.x = movementInfo.movementSpeed;

        else if (destination.x < transform.position.x)
            movementInfo.velocity.x = -movementInfo.movementSpeed;
    }

    protected bool ReachedDestination(Vector2 destination)
    {
        if (coll.bounds.Contains(new Vector2(destination.x, transform.position.y)))
            return true;

        else if (controller.collisionState.right || controller.collisionState.left)
            return true;
        
        else
            return false;
    }

    protected void UpdateFacing(float direction)
    {
        if (direction == 1)
        {
            if (facing == Direction.Left)
            {
                facing = Direction.Right;

                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (direction == -1)
        {
            if (facing == Direction.Right) 
            {
                facing = Direction.Left;

                controller.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}

public enum MovementPattern { None, Still, Wandering, Patrolling }
