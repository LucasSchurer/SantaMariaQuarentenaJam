﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform currentTarget;
    public Transform possibleTarget;
    private Transform temporaryTarget;
    public float changingTargetSpeedDamp = 2;
    public Vector3 offset;
    private bool isChangingTarget = false;
    private bool isWithTemporaryTarget = false;
    public float smoothDampTime = 0.5f;
    private Vector3 smoothDampVelocity;

    void Start()
    {
        PlayerAction.possibleHostSelected += ChangeTarget;
        PlayerAction.searchingForHost += ChangeTarget;
        PlayerAction.waterBlockedInfection += ChangeTargetTemporarily;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isWithTemporaryTarget && temporaryTarget != null)
            transform.position = Vector3.SmoothDamp(transform.position, temporaryTarget.position + offset, ref smoothDampVelocity, smoothDampTime);
        else if (isChangingTarget && possibleTarget != null)
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

    private void ChangeTargetTemporarily(Transform target)
    {
        temporaryTarget = target;
        StartCoroutine(ChangeTargetTemporarily(2f));
    }

    private IEnumerator ChangeTargetTemporarily(float time)
    {
        isWithTemporaryTarget = true;

        yield return new WaitForSeconds(time);

        isWithTemporaryTarget = false;
        temporaryTarget = null;

        yield return null;
    }


    void OnDestroy()
    {
        PlayerAction.possibleHostSelected -= ChangeTarget;
        PlayerAction.searchingForHost -= ChangeTarget;
        PlayerAction.waterBlockedInfection -= ChangeTargetTemporarily;
    }
}
