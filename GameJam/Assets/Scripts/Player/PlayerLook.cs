using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Transform cameraTransform;
    public Transform playerModel;
    
    public float sensitivity = 100f;
    private float cameraRotation;

    void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float inputY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        cameraRotation -= inputY;
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);
        playerModel.Rotate(Vector3.up * inputX);
    }
}
