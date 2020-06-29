using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterReflection : MonoBehaviour
{
    public Camera waterCamera;
    public GameObject waterImage;
    public Material waterMaterial;

    void Start()
    {
        if (waterCamera.targetTexture != null)
            waterCamera.targetTexture.Release();

        waterCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, 1);
        waterMaterial.SetTexture("_RenderTex", waterCamera.targetTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
