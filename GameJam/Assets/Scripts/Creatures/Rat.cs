using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Creature
{
    override public void UseAction()
    {
        // Pass through pipes
    }

    override public string GetName()
    {
        return "Rat";
    }

    override public Vector3 GetCameraPosition()
    {
        return new Vector3(0f, 0.26f, 0.252f);
    }
}
