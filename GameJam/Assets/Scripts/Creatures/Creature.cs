using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    abstract public void UseAction();

    abstract public string GetName();

    abstract public Vector3 GetCameraPosition();
}
