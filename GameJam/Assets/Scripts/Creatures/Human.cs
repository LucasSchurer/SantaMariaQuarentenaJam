using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Creature
{
    override public void UseAction()
    {
        // Open doors
    }

    override public string GetName()
    {
        return "Human";
    }

    override public Vector3 GetCameraPosition()
    {
        return new Vector3(0f, 0.796f, 0.21499f);
    }
}
