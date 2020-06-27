using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class Creature : MonoBehaviour
{
    private CreatureAI creatureAI;
    public bool isBeingControlled = false;

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

    abstract public Vector3 GetCameraPosition();
}
