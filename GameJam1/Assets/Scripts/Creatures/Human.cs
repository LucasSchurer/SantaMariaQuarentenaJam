using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Creature
{
    override public void UseAction()
    {
        // Open/close valves

        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        float direction = -Mathf.Sign(transform.localScale.x);

        print(direction == 1 ? "Right" : "Left");

        Vector2 origin = new Vector2(transform.position.x + (bounds.extents.x/2 * direction), transform.position.y);

        //Debug.DrawRay(origin, Vector2.right * direction, Color.cyan, 2f);

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.right * direction, 1f, 1 << 11 | 1 << 12);

        if (hit)
        {
            print(hit.collider.name);

            if (hit.collider.tag == "Valve")
            {
                hit.collider.SendMessage("ChangePipeState");
            }
        }
    }

    override public string GetName()
    {
        return "Human";
    }

    override public Vector2 GetEyePosition()
    {
        return new Vector2(0.2f, 0.351f);
    }

    override public Vector2 GetEyeScale()
    {
        return new Vector2(.40f, 0.16f);
    }
}
