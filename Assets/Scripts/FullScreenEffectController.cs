using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FullScreenEffectController : MonoBehaviour
{
    public UniversalRendererData rendererData;

    private void Start()
    {
        enableFogShader();
    }

    public void enableFogShader()
    {
        rendererData.rendererFeatures[1].SetActive(false);
        rendererData.rendererFeatures[0].SetActive(true);
    }

    public void enableSoulShader()
    {
        rendererData.rendererFeatures[0].SetActive(false);
        rendererData.rendererFeatures[1].SetActive(true);
    }
}
