using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionParticle : MonoBehaviour
{
    public Transform currentTarget;
    public float smoothDampTime = 0.5f;
    private Vector3 smoothDampVelocity;
    

    void Start()
    {
        if (currentTarget != null)
            transform.position = currentTarget.position;
    }
    
    void FixedUpdate()
    {
        if (currentTarget != null)
            transform.position = Vector3.SmoothDamp(transform.position, currentTarget.position, ref smoothDampVelocity, smoothDampTime);
    }
}
