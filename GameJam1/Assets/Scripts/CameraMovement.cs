using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform currentTarget;
    public Transform possibleTarget;
    public float changingTargetSpeedDamp = 2;
    public Vector3 offset;
    private bool isChangingTarget = false;
    public float smoothDampTime = 0.5f;
    private Vector3 smoothDampVelocity;

    void Start()
    {
        PlayerAction.possibleHostSelected += ChangeTarget;
        PlayerAction.searchingForHost += ChangeTarget;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isChangingTarget && possibleTarget != null)
            transform.position = Vector3.SmoothDamp(transform.position, possibleTarget.position + offset, ref smoothDampVelocity, smoothDampTime);
        else if (currentTarget != null)
            transform.position = Vector3.SmoothDamp(transform.position, currentTarget.position + offset, ref smoothDampVelocity, smoothDampTime);
    }

    public void ChangeTarget(Creature selectedCreature)
    {
        possibleTarget = selectedCreature.transform;
    }

    public void ChangeTarget(bool isSearchingForHost)
    {
        isChangingTarget = isSearchingForHost;

        if (!isChangingTarget)
            possibleTarget = null;
    }

    void OnDestroy()
    {
        PlayerAction.possibleHostSelected -= ChangeTarget;
        PlayerAction.searchingForHost -= ChangeTarget;
    }
}
