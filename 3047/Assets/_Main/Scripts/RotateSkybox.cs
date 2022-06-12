using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RotateSkybox : MonoBehaviour
{
    [SerializeField] private float _rotateSeed = 1f;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * _rotateSeed);
    }
}
