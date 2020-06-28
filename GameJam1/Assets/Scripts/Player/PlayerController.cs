using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Creature currentCreature;
    private PlayerMovement playerMovement;
    private PlayerAction playerAction;
    private CameraMovement cameraMovement;
    
    void Start()
    {
        PlayerAction.infectCreature += InfectedCreature;
        PlayerAction.searchingForHost += SearchingForHost;

        playerMovement = GetComponent<PlayerMovement>();
        playerAction = GetComponent<PlayerAction>();
        cameraMovement = Camera.main.GetComponent<CameraMovement>();

        // Update the infected creature
        currentCreature.StartInfection();
        currentCreature.gameObject.layer = gameObject.layer;

        // Set the movement controller to the current controlled creature
        playerMovement.controller = currentCreature.GetComponent<CharacterController>();

        // Set the current creature to the player action
        playerAction.currentCreature = currentCreature;

        // Adjust the camera
        cameraMovement.currentTarget = currentCreature.transform;
    }

    private void InfectedCreature(Creature newCreature)
    {
        currentCreature.EndInfection();
        currentCreature.gameObject.layer = 9;
        currentCreature = newCreature;

        currentCreature.gameObject.layer = gameObject.layer;
        currentCreature.StartInfection();

        playerMovement.controller = currentCreature.GetComponent<CharacterController>();
        playerAction.currentCreature = currentCreature;
        cameraMovement.currentTarget = currentCreature.transform;
    }

    private void SearchingForHost(bool isSearching)
    {
        ChangeSlowMotion(isSearching);
        playerMovement.canMove = !isSearching;
    }

    void OnDestroy()
    {
        PlayerAction.infectCreature -= InfectedCreature;   
        PlayerAction.searchingForHost -= SearchingForHost; 
    }

    private void ChangeSlowMotion(bool enabled)
    {
        if (enabled)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        } 
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }  
    }
}
