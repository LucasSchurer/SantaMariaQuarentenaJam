using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class Creature : MonoBehaviour
{
    private CreatureAI creatureAI;
    public bool isBeingControlled = false;
    protected Animator anim;

    void Awake()
    {
        creatureAI = GetComponent<CreatureAI>();
    }

    public void StartInfection()
    {
        isBeingControlled = true;
        creatureAI.enabled = false;
    }

    public void EndInfection()
    {
        isBeingControlled = false;
        creatureAI.enabled = true;
    }

    abstract public void UseAction();

    abstract public string GetName();

    abstract public Vector2 GetEyePosition();
    abstract public Vector2 GetEyeScale();
}
