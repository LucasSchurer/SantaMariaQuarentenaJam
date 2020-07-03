using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Creature
{
    override public void UseAction()
    {
        print("SQUEEEK");
    }

    override public string GetName()
    {
        return "Rat";
    }

    override public Vector2 GetEyePosition()
    {
        return new Vector2(4.5f, 0.4f);
    }

    override public Vector2 GetEyeScale()
    {
        return new Vector2(1, 1);
    }
}
