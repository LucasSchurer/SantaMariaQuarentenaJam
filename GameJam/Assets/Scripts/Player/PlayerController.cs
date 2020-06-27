using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerAction action;
    private PlayerLook look;
    private PlayerMovement movement;
    public Creature currentCreature;
    public Transform playerModel;

    void Awake()
    {
        action = GetComponent<PlayerAction>();
        look = GetComponent<PlayerLook>();
        movement = GetComponent<PlayerMovement>();

        currentCreature = playerModel.GetComponent<Creature>();

        action.playerModel = playerModel;
        
        look.playerModel = playerModel;

        movement.controller = playerModel.GetComponent<Rigidbody>();
        
        Camera.main.transform.parent = playerModel;
        Camera.main.transform.localPosition = currentCreature.GetCameraPosition();
        
        PlayerAction.infectCreature += ChangeCreature;

        playerModel.gameObject.layer = gameObject.layer;

        print(currentCreature.GetName());
    }

    void ChangeCreature()
    {

    }

    

    


}
