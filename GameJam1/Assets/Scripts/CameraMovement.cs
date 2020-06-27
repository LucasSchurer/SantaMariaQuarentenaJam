using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform currentTarget;

    // Update is called once per frame
    void LateUpdate()
    {
        if (currentTarget != null)
            transform.position = new Vector3(currentTarget.position.x, transform.position.y, transform.position.z);
    }
}
