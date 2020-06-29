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
        return new Vector2(.324f, 0f);
    }

    override public Vector2 GetEyeScale()
    {
        return new Vector2(0.28f, 0.621f);
    }
}
