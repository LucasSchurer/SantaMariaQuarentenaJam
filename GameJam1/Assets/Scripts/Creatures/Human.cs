using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Creature
{
    override public void UseAction()
    {
        // Open doors
        BoxCollider2D coll = GetComponent<BoxCollider2D>();
        Vector2 origin = new Vector2(transform.position.x + coll.bounds.size.x/2, transform.position.y);
        RaycastHit2D hit = Physics2D.BoxCast(origin, coll.bounds.size, 0f, Vector2.right, 0.5f, 1 << 11 | 1 << 12);
        if (hit)
        {
            if (hit.collider.tag == "Door")
            {
                hit.collider.SendMessage("OpenDoor");
            }
        }
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
