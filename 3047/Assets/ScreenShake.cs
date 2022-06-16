using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//https://www.youtube.com/watch?v=9A9yj8KnM8c
public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void StartShake(float duration, float magnitude)
    {
        StartCoroutine(CameraShake(duration, magnitude));
    }
    public IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 originalPos = Vector3.zero; //para resetear la posicion es el cameraHolder
        float elapsed = 0;
        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            
            yield return null;//esto espera al siguiente frame para la proxinma iteracion el while 
        }

        transform.localPosition = originalPos;
        
    }
}
