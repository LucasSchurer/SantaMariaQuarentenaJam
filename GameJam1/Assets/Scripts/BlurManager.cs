using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurManager : MonoBehaviour
{
    public Camera blurCamera;
    public GameObject blurImage;
    public Material blurMaterial;
    void Start()
    {
        if (blurCamera.targetTexture != null)
            blurCamera.targetTexture.Release();

        blurCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, 1);
        blurMaterial.SetTexture("_RenderTex", blurCamera.targetTexture);

        PlayerAction.searchingForHost += ChangeBlur;
    }

    private void ChangeBlur(bool enable)
    {
        blurCamera.gameObject.SetActive(enable);
        blurImage.SetActive(enable);
    }

    void OnDestroy()
    {
        PlayerAction.searchingForHost -= ChangeBlur;
    }
}
