using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Creature currentCreature;
    public Transform infectedEye;
    public InfectionParticle infectionParticle;
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

        playerMovement.facing = currentCreature.facing;

        // Update the infected creature
        currentCreature.StartInfection();
        currentCreature.gameObject.layer = gameObject.layer;

        // Set the movement controller to the current controlled creature
        playerMovement.controller = currentCreature.GetComponent<CharacterController>();
        playerMovement.infectedCreatureAnimator = currentCreature.GetComponent<Animator>();

        // Set the current creature to the player action
        playerAction.currentCreature = currentCreature;

        // Adjust the camera
        cameraMovement.currentTarget = currentCreature.transform;

        // Adjust the eye
        if (infectedEye != null)
        {
            infectedEye.SetParent(currentCreature.transform);
            infectedEye.localPosition = currentCreature.GetEyePosition();
            infectedEye.localScale = currentCreature.GetEyeScale();
        }

        infectionParticle.currentTarget = currentCreature.transform;

        currentCreature.GetComponent<CharacterController>().onTriggerEnterEvent += OnTriggerEnterEvent;
        currentCreature.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void InfectedCreature(Creature newCreature)
    {
        currentCreature.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        currentCreature.GetComponent<CharacterController>().onTriggerEnterEvent -= OnTriggerEnterEvent;
        currentCreature.facing = playerMovement.facing;
        currentCreature.EndInfection();
        currentCreature.gameObject.layer = 9;
        currentCreature = newCreature;

        playerMovement.facing = currentCreature.facing;

        currentCreature.gameObject.layer = gameObject.layer;
        currentCreature.StartInfection();

        playerMovement.controller = currentCreature.GetComponent<CharacterController>();
        playerMovement.infectedCreatureAnimator = currentCreature.GetComponent<Animator>();
        
        playerAction.currentCreature = currentCreature;
        cameraMovement.currentTarget = currentCreature.transform;

        if (infectedEye != null)
        {
            infectedEye.SetParent(currentCreature.transform);
            infectedEye.localPosition = currentCreature.GetEyePosition();
            infectedEye.localScale = currentCreature.GetEyeScale();
        }
        
        infectionParticle.currentTarget = currentCreature.transform;

        currentCreature.GetComponent<CharacterController>().onTriggerEnterEvent += OnTriggerEnterEvent;
        currentCreature.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
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
        if (currentCreature != null)
            currentCreature.GetComponent<CharacterController>().onTriggerEnterEvent -= OnTriggerEnterEvent;
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

    private void OnTriggerEnterEvent(Collider2D coll)
    {
        print(coll.name);
    }
}
