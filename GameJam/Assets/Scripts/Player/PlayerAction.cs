using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public delegate void InfectCreature();
    public static event InfectCreature infectCreature;
    public float infectRadius = 10f;
    public LayerMask infectMask;
    public Transform playerModel;

    // Update is called once per frame
    void Update()
    {
        // Check if there is creatures that can be infected around the player
        Collider[] hits = Physics.OverlapSphere(playerModel.position, infectRadius, infectMask);
        if (hits != null)
        {
            foreach (Collider hit in hits)
            {   
                print(hit.name);
            }
        }
        
        RaycastHit hita;
        Ray ray = Camera.main.ViewportPointToRay(Input.mousePosition);
        

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

        if (Physics.Raycast(ray.origin, ray.direction, out hita, infectRadius, infectMask))
        {
            print(hita.transform.name);
        }       

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Use creature action
        }
    }
}
